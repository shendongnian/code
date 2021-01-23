     string n = "2.2222";
            string[] s = n.Split('.');
                           
            if (s[1].Count() >= 3)
            {
                List<char> z = s[1].ToString().Take(2).ToList();
                int c=Convert.ToInt32(z[0].ToString() + z[1].ToString()) + 1;
              //  int b = Convert.ToInt32(s[1].ElementAt(0).ToString() + s[1].ElementAt(1).ToString()) + 1;
                string output= s[0] + "." + c.ToString();            
            }
