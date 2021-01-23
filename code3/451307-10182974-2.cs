    List<string> mylist = new List<string>();
            List<string> mysearches = new List<string>();
            string data1 = "test1";
            string data2 = "test2";
            string data3 = "test3";
            string data4 = "test4";
            
            if(data1 != "Do not Search")
                mysearches.Add(data1);
            if (data2 != "Do not Search")
                mysearches.Add(data2);
            if (data3 != "Do not Search")
                mysearches.Add(data3);
            if (data4 != "Do not Search")
                mysearches.Add(data4);
            bool found = false;
            bool andconditionmatch = true;
            foreach (string s in mylist)
            {
                if (mysearches.Contains(s))
                {
                    found = true;
                }
                else
                {
                    andconditionmatch = false;
                }
            }
            
