        private static void Main(string[] args)
        {            
            byte[] bytes = null;
            var gcHandle = new GCHandle();
  
            Native.foo(size =>
                            {
                                bytes = new byte[size];
                                gcHandle = GCHandle.Alloc(bytes,GCHandleType.Pinned);
                                return gcHandle.AddrOfPinnedObject();
                            });
            
            if(gcHandle.IsAllocated)
                gcHandle.Free();
            string s = ASCIIEncoding.ASCII.GetString(bytes);
            Console.WriteLine(s);
        }
