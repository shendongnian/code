        static void Main(string[] args)
        {
            try
            {
                using (ZipFile zip1 = new ZipFile())
                {
                    zip1.AddFile(@"SCAN0002.PDF");
                    zip1.AddFile(@"SCAN0003.PDF");
                    zip1.Save("SCAN0002.ZIP");
                }
                using (ZipFile zip2 = new ZipFile())
                {
                    zip2.AddFile(@"SCAN0004.PDF");
                    zip2.AddFile(@"SCAN0005.PDF");
                    zip2.AddFile(@"SCAN0006.PDF");
                    zip2.Save("SCAN0003.ZIP");
                }
                ZipFile z3 = new ZipFile().Read2(File.ReadAllBytes("SCAN0002.ZIP"));
                ZipFile z4 = new ZipFile().Read2(File.ReadAllBytes("SCAN0003.ZIP"));
                using (ZipFile zip3 = new ZipFile())
                {
                    zip3.Marge(z3).Marge(z4);
                    zip3.Save("SCAN0004.ZIP");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
