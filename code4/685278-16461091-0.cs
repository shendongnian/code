     public DataTable GetPNR(List<string> Request)  // Here we create the function for get pnr.
        {
            dt.Columns.Add("PNR", typeof(string));
        
            foreach (string data in Request)
            {
                string item = data;
                dr = dt.NewRow();
                Regex regex = new Regex(@"(\d+\.[a-zA-Z]\S(.+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                foreach (Match m in regex.Matches(item))
                {
                    name = m.ToString();
                }
                if((item.ToLower().Contains("itinerary rebooked") || item.ToLower().Contains("itineraryrebooked"))&&name!=null) // Condition for operated by cases
                {
                    Regex regexs = new Regex(@"(\s[A-Z0-9]{6}\s{2})"); // Regular operation for PNR.
                    foreach (Match m in regexs.Matches(item))
                    {
                        output = m.ToString(); // Here we store the PNR value in output string variable.
                    }
                   
                }
                dr["PNR"] = output;
                dt.Rows.Add(dr);
            }
            return dt;
        }`enter code here`
