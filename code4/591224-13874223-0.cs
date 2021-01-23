                    Array.Reverse(array);  
                    Boolean dot = false;
                    for (int j = 0; j < array.Length; j++)
                    {   
                        char letter = array[j];
                        if (char.IsNumber(letter))
                        {
                            version += letter.ToString();
                        }
                        else if (letter == '.')
                        {
                            if (dot)
                            {
                                break;
                            }
                            dot = true;
                        }
                   }
                    version = this.Reverse(version);
                    if (version.Equals(""))
                    {
                        version = "0";
                    }
