          using (System.IO.FileStream File = new System.IO.FileStream(e.FullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    using (System.IO.StreamReader Reader = new System.IO.StreamReader(File, Encoding.Default))
                    {
                        String CompleteData = Reader.ReadToEnd();
                        foreach (String Line in CompleteData.Split(new char[] { (char)13 }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (Line.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[0].Contains("Raising event"))
                            {
                                 //Do Stuff
                            }
                        }
                        Reader.Close();
                    }
                    File.Close();
                }
