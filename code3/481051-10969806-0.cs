    range = objSheet.get_Range("C17:C42", Missing.Value);
                    object[,] numbers3 = new object[26,1];
                    for (int i = 0; i<= richTextBoxReceive.Lines.Length; i++)
                    {
                        for (int j = 0; j <= 25; j++)
                        {
                            numbers3[j, 0] = richTextBoxReceive.Lines[j + 1];
                        }
    
                    }
