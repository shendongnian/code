        static void Main(string[] args)
        {
            string path = Path.GetTempPath();
            byte[] binaryData;
            string text = "romil123456";
            using (MemoryStream memStream = new MemoryStream(Encoding.ASCII.GetBytes(text)))
                {
                    binaryData = memStream.ToArray();
                }
                System.IO.File.WriteAllBytes(@path + "\\words123.txt"    , binaryData);
            }
        }
