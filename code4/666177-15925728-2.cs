     using (TextWriter TW = new StreamWriter(@"c:\file.txt", true))
                {
                    foreach (var text in comboBox1.Items)
                    {
                        TW.WriteLine();
                    }
                }
