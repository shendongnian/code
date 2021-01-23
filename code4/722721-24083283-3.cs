        public static void ConversionTest()
        {
            var bufferType = typeof(Buffer);
            unsafe
            {
                var paramList = new Type[3] { typeof(byte*), typeof(byte*), typeof(int) };
                var memcpyimplMethod = bufferType.GetMethod("Memcpy", BindingFlags.Static | BindingFlags.NonPublic, null, paramList, null);
                memcpyimpl = (MemCpyImpl)Delegate.CreateDelegate(typeof(MemCpyImpl), memcpyimplMethod);
            }
            Struct1[] s1Array = { new Struct1() { value = 123456789 } };
            var converter = new Struct12Converter { S1Array = s1Array };
            var s2Array = new Struct2[1];
            unsafe
            {
                fixed (void* bad = s2Array)
                {
                    fixed (void* idea = converter.S2Array)
                    {
                        Copy(bad, idea, 4);
                    }
                }
            }
        }
