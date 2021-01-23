            //string patt = "@(?<value>.*?)@";
            string patt = "@(?<value>\\d*?)@";  //  just number values (if there should be an integer use + instead of *)
            string str = "@1234@ == val1 && @2312@ != val2";
            MatchCollection mc;
            Regex r = new Regex(patt);
            mc = r.Matches(str);
            List<string> lst = new List<string>();
            foreach (Match item in mc)
            {
                string value = item.Groups["value"].Value;
                lst.Add(value);
            }
