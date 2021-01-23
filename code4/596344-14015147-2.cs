    static List<string> ReadFile(string Path, string Section)
    {
        #region Declare Variables
        string[] Lines = File.ReadAllLines(Path); //Read Path into Lines
        int CurrentValue = 1; //Declare CurrentValue as an Integer of value 1
        List<string> RequiredValues = new List<string>(); //Initialize a new List of string of name RequiredValues
        #endregion
        #region Collect Information
        //Look through the section getting the data between [ and ]);
        for (int i = 0; i < Lines.Length; i++)
        {
            if (Lines[i].StartsWith("{" + Section + "}"))
            {
                i++;
                while (!Lines[i].StartsWith("{") && !Lines[i].EndsWith("}"))
                {
                    i++;
                    if (Lines.Length > i)
                    {
                        if (Lines[i].Contains('['))
                        {
                            while (true)
                            {
                                i++;
                                if (Lines[i].Contains("]);"))
                                {
                                    break;
                                }
                                RequiredValues.Add(Section + "[" + CurrentValue.ToString() + "] = " + Lines[i]);
                                CurrentValue++;
                            }
                        }
                        RequiredValues.Add("");
                    }
                    else
                    {
                        break; //Reached the end of the document
                    }
                }
            }
        }
        #endregion
        return RequiredValues; //Return RequiredValues
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        List<string> Contents = ReadFile(@"C:\Base_Model.txt", "Atom: Verdieping 2");
        foreach (string str in Contents)
        {
            System.Diagnostics.Debug.WriteLine(str); //Write str to the trace listeners
        }
    }
