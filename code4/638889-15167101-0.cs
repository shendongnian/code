                decimal input;
                int offset;
                string working = input.ToString();
                int decIndex = working.IndexOf('.');
                if (offset > 0)
                {
                    if (decIndex == -1)
                    {
                        working.PadLeft(offset, '0');
                        working.Insert(working.Length - offset, ".");
                    }
                    else
                    {
                        working.Remove(decIndex, 1);
                        decIndex -= offset;
                        while (decIndex < 0)
                        {
                            working.Insert(0, "0");
                            decIndex++;
                        }
                        working.Insert(decIndex, ".");
                    }
                }
                else if (offset < 0)
                {
                    if (decIndex == -1)
                    {
                        decIndex = working.Length();
                    }
                    if (decIndex + offset > working.Length)
                    {
                        working.PadRight(working.Length - offset, '0');
                    }
                    else
                    {
                        working.Remove(decIndex, 0);
                        working.Insert(decIndex + offset, ".");
                    }
                    
                }
