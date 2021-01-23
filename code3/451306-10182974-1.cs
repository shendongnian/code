            List<string> mylist = new List<string>();
            string data1 = "test1";
            string data2 = "test2";
            string data3 = "test3";
            string data4 = "test4";
            
            foreach (string s in mylist)
            {
                bool found = false;
                bool notfound = false;
                if(data1.Equals(s) || data1.Equals("Do not Search"))
                {
                    found = true;
                }
                else
                {
                    notfound = true;
                }
                if (data2.Equals(s) || data1.Equals("Do not Search"))
                {
                    found = true;
                }
                else
                {
                    notfound = true;
                }
                if (data3.Equals(s) || data1.Equals("Do not Search"))
                {
                    found = true;
                }
                else
                {
                    notfound = true;
                }
                if (data4.Equals(s) || data1.Equals("Do not Search"))
                {
                    found = true;
                }
                else
                {
                    notfound = true;
                }
                // Force all to match
                if (notfound)
                    return null;
            }
