    namespace hex2bin
    {
        class Program
        {
            public static void hex2bin(TextReader sin, BinaryWriter sout)
            {
                char[] block = new char[2];
                bool eof = false;
                do
                {
                    int chars = sin.ReadBlock(block, 0, 2);
                    switch (chars)
                    {
                        case 0:
                            eof = true;
                            break;
                        case 1:
                            // Input is odd length, invalid case
                            throw new Exception("Invalid input");
                        case 2:
                            string sblock = new String(block);
                            byte b = Convert.ToByte(sblock, 16);
                            sout.Write(b);
                            break;
                    }
                } while (!eof);
    
            }
    
            static void Main(string[] args)
            {
                using (StringReader sr = new StringReader("AD5829FC"))
                {
                    using (BinaryWriter bw = new BinaryWriter(new MemoryStream()))
                    {
                        hex2bin(sr, bw);
                    }
                }
            }
        }
    }
