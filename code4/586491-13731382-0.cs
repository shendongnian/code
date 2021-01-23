    void Main()
    {
    	// Carve out a 100x100 chunk
    	var top = 100;
    	var left = 100;
    	var bottom = 300;
    	var right = 300;
    
    	// For BMP only - open input
    	var fs = File.OpenRead(@"c:\temp\testbmp.bmp");
    	
    	// Open output
    	if(File.Exists(@"c:\temp\testbmp.cropped.bmp")) File.Delete(@"c:\temp\testbmp.cropped.bmp");
    	var output = File.Open(@"c:\temp\testbmp.cropped.bmp", FileMode.CreateNew);
    	var bw = new BinaryWriter(output);
    
    	// Read out the BMP header fields
    	var br = new BinaryReader(fs);
    	var headerField = br.ReadInt16();
    	var bmpSize = br.ReadInt32();
    	var reserved1 = br.ReadInt16();
    	var reserved2 = br.ReadInt16();
    	var startOfData = br.ReadInt32();	
    	
    	// Read out the BMP DIB header
    	var header = new BITMAPV5Header();	
    	var headerBlob = br.ReadBytes(Marshal.SizeOf(header));
    	var tempMemory = Marshal.AllocHGlobal(Marshal.SizeOf(header));
    	Marshal.Copy(headerBlob, 0, tempMemory, headerBlob.Length);
    	header = (BITMAPV5Header)Marshal.PtrToStructure(tempMemory, typeof(BITMAPV5Header));
    	Marshal.FreeHGlobal(tempMemory);
    
    	// This file is a 24bpp rgb bmp, 
    	var format = PixelFormats.Bgr24;
    	var bytesPerPixel = (int)(format.BitsPerPixel / 8);
    	Console.WriteLine("Bytes/pixel:{0}", bytesPerPixel);
    	
    	// And now I know its dimensions
    	var imageWidth = header.ImageWidth;
    	var imageHeight = header.ImageHeight;
    	Console.WriteLine("Input image is:{0}x{1}", imageWidth, imageHeight);
    
    	var fromX = left;
    	var toX = right;
    	var fromY = imageHeight - top;
    	var toY = imageHeight - bottom;
    
    	// How "long" a horizontal line is
    	var strideInBytes = imageWidth * bytesPerPixel;
    	Console.WriteLine("Stride size is:0x{0:x}", strideInBytes);
    	
    	// new size
    	var newWidth = Math.Abs(toX - fromX);
    	var newHeight = Math.Abs(toY - fromY);
    	Console.WriteLine("New slice dimensions:{0}x{1}", newWidth, newHeight);
    	
    	// Write out headers to output file 
    	{
    		// header = "BM" = "Windows Bitmap"
    		bw.Write(Encoding.ASCII.GetBytes("BM"));	
    		var newSize = 14 + Marshal.SizeOf(header) + (newWidth * newHeight * bytesPerPixel);
    		Console.WriteLine("New File size: 0x{0:x} bytes", newSize);
    		bw.Write((uint)newSize);	
    		// 2 reserved shorts
    		bw.Write((ushort)0);	
    		bw.Write((ushort)0);			
    		// offset to "data"
    		bw.Write(header.HeaderSize + 14);
    		
    		// Tweak size in header to cropped size
    		header.ImageWidth = newWidth;
    		header.ImageHeight = newHeight;
    
    		// Write updated DIB header	to output
    		tempMemory = Marshal.AllocHGlobal(Marshal.SizeOf(header));
    		Marshal.StructureToPtr(header, tempMemory, true);
    		byte[] asBytes = new byte[Marshal.SizeOf(header)];
    		Marshal.Copy(tempMemory, asBytes, 0, asBytes.Length);
    		Marshal.FreeHGlobal(tempMemory);
    		bw.Write(asBytes);
    		asBytes.Dump();
    	}
    
    	// Jump to where the pixel data is located (on input side)
    	Console.WriteLine("seeking to position: 0x{0:x}", startOfData);
    	fs.Seek(startOfData, SeekOrigin.Begin);
    	
    	var sY = Math.Min(fromY, toY);
    	var eY = Math.Max(fromY, toY);
    	for(int currY = sY; currY < eY; currY++)
    	{
    		long offset =  startOfData + ((currY * strideInBytes) + (fromX * bytesPerPixel));
    		fs.Seek(offset, SeekOrigin.Begin);		
    		
    		// Blast in each horizontal line of our chunk
    		var lineBuffer = new byte[newWidth * bytesPerPixel];
    		int bytesRead = fs.Read(lineBuffer, 0, lineBuffer.Length);
    		output.Write(lineBuffer, 0, lineBuffer.Length);
    	}
    	
    	fs.Close();
    	output.Close();
    }
    
    [StructLayout(LayoutKind.Sequential, Pack=0)]
    public struct BITMAPV5Header 
    {
    	public uint HeaderSize;
    	public int ImageWidth;
    	public int ImageHeight;
    	public ushort Planes;
    	public ushort BitCount;
    	
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst=36)]
    	public byte[] DontCare;
    }
