            byte[] pdfBytes = File.ReadAllBytes("c:\foo.pdf");
            int fileSize = pdfBytes.Length / 5; //assuming foo is 40MB filesize will be abt 8MB
            MemoryStream m = new MemoryStream(pdfBytes);
            for (int i = 0; i < 4; i++)
            {
                byte[] tbytes = new byte[fileSize];
                m.Read(tbytes,i*fileSize,fileSize);
                File.WriteAllBytes("C:\foo" + i + ".part",tbytes);
            }
