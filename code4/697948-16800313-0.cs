            foreach (string s in partsComb)
            {
                //s.Split(delimiters);
               // s.Trim();
                partsComb.Equals(s);
                //output.WriteLine(s.Replace("      ", ",")); // takes away all blank spaces and replaces them with comma for the CSV file output
                output.WriteLine(s);
            }
            output.Close();
        }
