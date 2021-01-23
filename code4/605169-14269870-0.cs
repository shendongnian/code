    void Main()
    {
    	var pts = 
    		(from x in Enumerable.Range(0, 10)
    		from y in Enumerable.Range(0, 10)
    		from z in Enumerable.Range(0, 10)
    		select new Vector3(){X = x, Y = y, Z = z}).ToArray();
    	
    	// write it out...
    	var bigAssByteArray = new byte[Marshal.SizeOf(typeof(Vector3)) * pts.Length];
    	var pinnedHandle = GCHandle.Alloc(pts, GCHandleType.Pinned);	
    	Marshal.Copy(pinnedHandle.AddrOfPinnedObject(), bigAssByteArray, 0, bigAssByteArray.Length);
    	pinnedHandle.Free();
    	File.WriteAllBytes(@"c:\temp\vectors.out", bigAssByteArray);
    	
    	// ok, read it back...
    	var readBytes = File.ReadAllBytes(@"c:\temp\vectors.out");
    	var numVectors = readBytes.Length / Marshal.SizeOf(typeof(Vector3));
    	var readVectors = new Vector3[numVectors];
    	pinnedHandle = GCHandle.Alloc(readVectors, GCHandleType.Pinned);
    	Marshal.Copy(readBytes, 0, pinnedHandle.AddrOfPinnedObject(), readBytes.Length);
    	pinnedHandle.Free();
    	
    	var allEqual = 
    		pts.Zip(readVectors, 
    			(v1,v2) => (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z))
    		.All(p => p);
    	Console.WriteLine("pts == readVectors? {0}", allEqual);
    }
    
    
    struct Vector3
    {
    	public float X;
    	public float Y;
    	public float Z;
    }
