    string line;
    using (StreamReader file = new StreamReader(@"C:\Users\Desktop\snpprivatesellerlist.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            string st;
            DateTime dtPart;
            float flPart;
            char[] delimiters = new char[] { '\n' };
            string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                st = parts[i];
                if (DateTime.TryParse(st, out dtPart))//Is of type DateTime
                {
                    //Do something with DateTime dtPart
                }
                else if (float.TryParse(st, out flPart))//Is of type float
                {
                    //Do something with float flPart
                }
                else//Can be considered a string
                {
                    //Do something with string st
                }
            }
        }
    }
