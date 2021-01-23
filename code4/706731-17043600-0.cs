    try
                    {
                        int i;
                        string output = "";
        
                        string Selected = "12.FaceBook";
                        int k = 3;
                        string[] myArray = new string[Selected.Length];
                        for (i = 0; i < Selected.Length-3; i++)
                        {
                            myArray[i] = Selected[k].ToString();
        
                            output = output + myArray[i];
                            k++;
                        }
        
        
                        DevComponents.DotNetBar.MessageBoxEx.Show(output);
                    }
                    catch (Exception ee)
                    {
        
                    }
