    private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("desk","table");
    
            
            string input = "Desk";
            var dictValue = dict[input.ToLower()];
            var result = IsInitCap(input.Substring(0, 1)) 
                         ? System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(dictValue)
                         : dictValue;                
               
        }
    
        private bool IsInitCap(string str)
        {
            Match match = Regex.Match(str, @"^[A-Z]");
            return match.Success ? true : false;
        }
