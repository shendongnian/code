        // http://msdn.microsoft.com/en-us/library/windows/desktop/dd757688(v=vs.85).aspx
        [StructLayout(LayoutKind.Sequential)]
        private struct VIDEOHDR 
        {
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa383751(v=vs.85).aspx
            // typedef unsigned char BYTE;
            // typedef BYTE far *LPBYTE;
            // unsigned char* lpData
            //public byte[] lpData; // LPBYTE    lpData; // Aaargh, invalid cast, not a .NET byte array...
            public IntPtr lpData; // LPBYTE    lpData;
            public UInt32 dwBufferLength; // DWORD     dwBufferLength;
            public UInt32 dwBytesUsed; // DWORD     dwBytesUsed;
            public UInt32 dwTimeCaptured; // DWORD     dwTimeCaptured;
            // typedef ULONG_PTR DWORD_PTR;
            // #if defined(_WIN64)  
            //   typedef unsigned __int64 ULONG_PTR;
            // #else
            //   typedef unsigned long ULONG_PTR;
            // #endif
            public IntPtr dwUser; // DWORD_PTR dwUser; 
            public UInt32 dwFlags; // DWORD     dwFlags;
            
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 4)]
            public System.UIntPtr[] dwReserved; // DWORD_PTR dwReserved[4];
            // Does not make a difference
            //public System.UIntPtr[] dwReserved = new System.UIntPtr[4]; // DWORD_PTR dwReserved[4];
        }
        private delegate System.IntPtr capVideoStreamCallback_t(System.UIntPtr hWnd, ref VIDEOHDR lpVHdr);
        [DllImport("user32", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, capVideoStreamCallback_t routine);
        
        // http://eris.liralab.it/yarpdoc/vfw__extra__from__wine_8h.html
        private const int WM_USER = 0x0400; // 1024
        private const int WM_CAP_START = WM_USER;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        
        private const int WM_CAP_FILE_SAVEDIB = WM_CAP_START + 25;
        private const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
        private const int WM_CAP_GRAB_FRAME = WM_CAP_START + 60;
        private const int WM_CAP_EDIT_COPY = WM_CAP_START + 30;
        // http://lists.ximian.com/pipermail/mono-devel-list/2011-March/037272.html
        private static byte[] baSplendidIsolation;
        private static System.IntPtr capVideoStreamCallback(System.UIntPtr hWnd, ref VIDEOHDR lpVHdr)
        {
            //System.Windows.Forms.MessageBox.Show("hello");
            //System.Windows.Forms.MessageBox.Show(lpVHdr.dwBufferLength.ToString() + " " + lpVHdr.dwBytesUsed.ToString());
            byte[] _imageTemp = new byte[lpVHdr.dwBufferLength];
            Marshal.Copy(lpVHdr.lpData, _imageTemp, 0, (int) lpVHdr.dwBufferLength);
            //System.IO.File.WriteAllBytes(@"d:\temp\mycbfile.bmp", _imageTemp); // AAaaarg, it's raw bitmap data...
            // http://stackoverflow.com/questions/742236/how-to-create-a-bmp-file-from-byte-in-c-sharp
            // http://stackoverflow.com/questions/2654480/writing-bmp-image-in-pure-c-c-without-other-libraries
            // Tsssss... 350 x 350 was the expected setting, but never mind... 
            // fortunately alex told me about WM_CAP_FILE_SAVEDIB, so I could compare to the direct output
            int width = 640;
            int height = 480;
            int stride = width*3;
            baSplendidIsolation = null;
            baSplendidIsolation = WriteBitmapFile(@"d:\temp\mycbfilecc.bmp", width, height, _imageTemp);
            /*
            unsafe
            {
                fixed (byte* ptr = _imageTemp)
                {
                    using (Bitmap image = new Bitmap(width, height, stride, PixelFormat.Format24bppRgb, new IntPtr(ptr)))
                    {
                        image.Save(@"d:\temp\mycbfile2.bmp");
                    }
                }
            }
            */
            //var hdr = (Elf32_Phdr)Marshal.PtrToStructure(ptr, typeof(Elf32_Phdr));
            return System.IntPtr.Zero;
        }
        private static byte[] WriteBitmapFile(string filename, int width, int height, byte[] imageData)
        {
            using (var stream = new MemoryStream(imageData))
            using (var bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0,bmp.Width, bmp.Height)
                                                    ,ImageLockMode.WriteOnly
                                                    ,bmp.PixelFormat
                );
                Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);
                bmp.UnlockBits(bmpData);
                if (bmp == null)
                    return null;
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                bmp.Save(filename); // For testing only
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);    // get bitmap bytes
                    return ms.ToArray();
                } // End Using stream
            }
        } // End Function WriteBitmapFile
        /// <summary>
        /// Captures a frame from the webcam and returns the byte array associated
        /// with the captured image
        /// </summary>
        /// <param name="connectDelay">number of milliseconds to wait between connect 
        /// and capture - necessary for some cameras that take a while to 'warm up'</param>
        /// <returns>byte array representing a bitmp or null (if error or no webcam)</returns>
        private static byte[] InternalCaptureToByteArray(int connectDelay = 500)
        {
            Clipboard.Clear(); 
            int hCaptureWnd = capCreateCaptureWindowA("ccWebCam", 0, 0, 0,
                350, 350, 0, 0); // create the hidden capture window
            SendMessage(hCaptureWnd, WM_CAP_DRIVER_CONNECT, 0, 0); // send the connect message to it
            //SendMessage(hCaptureWnd, WM_CAP_DRIVER_CONNECT, i, 0); // i device number retval != 0 --> valid device_id
            
            Thread.Sleep(connectDelay);                                     // sleep the specified time
            SendMessage(hCaptureWnd, WM_CAP_SET_CALLBACK_FRAME, 0, capVideoStreamCallback);
            SendMessage(hCaptureWnd, WM_CAP_GRAB_FRAME, 0, 0);               // capture the frame
            //SendMessage(hCaptureWnd, WM_CAP_FILE_SAVEDIB, 0, "d:\\temp\\testmywebcamimage.bmp");
            //ScreenshotWindow(new IntPtr(hCaptureWnd));
            //SendMessage(hCaptureWnd, WM_CAP_EDIT_COPY, 0, 0); // copy it to the clipboard
            
            // using (Graphics g2 = Graphics.FromHwnd(new IntPtr(hCaptureWnd)))
            SendMessage(hCaptureWnd, WM_CAP_DRIVER_DISCONNECT, 0, 0);              // disconnect from the camera
            return baSplendidIsolation;
            /*
            Bitmap bitmap = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);  // copy into bitmap
            if (bitmap == null)
                return null;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);    // get bitmap bytes
                return stream.ToArray();
            } // End Using stream
            */
        } // End Function InternalCaptureToByteArray
