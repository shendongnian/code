            using (StreamWriter writer = File.CreateText(@"*DIRECTORY*\FINALOUTPUT.txt"))
            {
                using (StreamReader reader1 = File.OpenText(@"*DIRECTORY*\FIRSTFILE.txt"))
                {
                    using (StreamReader reader2 = File.OpenText(@"*DIRECTORY*\SECONDFILE.txt"))
                    {
                        string line1 = null;
                        string line2 = null;
                        while ((line1 = reader1.ReadLine()) != null)
                        {
                            writer.WriteLine(line1);
                            line2 = reader2.ReadLine();
                            if(line2 != null)
                            {
                                writer.WriteLine(line2);
                            }
                        }
                    }
                }
            }
