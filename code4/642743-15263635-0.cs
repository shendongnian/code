    protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("ABC", 2);
            dictionary.Add("DEF", 3);
            dictionary.Add("GHI", 4);
            dictionary.Add("JKL", 5);
            dictionary.Add("MNO", 6);
            dictionary.Add("PQRS", 7);
            dictionary.Add("TUV", 8);
            dictionary.Add("WXYZ", 9);
    
    
            string value = "BAL";
            string nummber = "#";
            foreach (char c in value)
            {
    
                nummber += dictionary.FirstOrDefault(d => d.Key.Contains(c)).Value.ToString();
            }
            nummber += "#";
    
        }
