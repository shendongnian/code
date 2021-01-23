            string CurrentLine = String.Empty;
            int CurrentPosition = 0;
            int CurrentSplit = 0;
            foreach (string file in Directory.GetFiles(@"C:\FilesToSplit"))
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(file))
                {
                    while ((CurrentLine = sr.ReadLine()) != null)
                    {
                        if (CurrentPosition == 130000) // Or whatever you want to split by.
                        {
                            using (StreamWriter sw = new StreamWriter(@"C:\FilesToSplit\SplitFiles\" + Path.GetFileNameWithoutExtension(file) + "-" + CurrentSplit + "." + Path.GetExtension(file)))
                            {
                                // Append this line too, so we don't lose it.
                                sb.Append(CurrentLine);
                                // Write the StringBuilder contents
                                sw.Write(sb.ToString());
                                // Clear the StringBuilder buffer, so it doesn't get too big. You can adjust this based on your computer's available memory.
                                sb.Clear();
                                // Increment the CurrentSplit number.
                                CurrentSplit++;
                                // Reset the current line position. We've found 130,001 lines of text.
                                CurrentPosition = 0;
                            }
                        }
                        else
                        {
                            sb.Append(CurrentLine);
                            CurrentPosition++;
                        }
                    }
                }
                // Reset the integers at the end of each file check, otherwise it can quickly go out of order.
                CurrentPosition = 0;
                CurrentSplit = 0;
            }
