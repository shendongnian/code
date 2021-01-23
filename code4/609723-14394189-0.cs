              string test = "((12-5=10)&&(5-4>6))";
            string[] Arr= test.Split(new string[{"(",")"},StringSplitOptions.RemoveEmptyEntries);
            List<string> newArr = new List<string>();
             int h=0;
            foreach (string s in Arr)           
            { 
                if (s != "&&")
                    newArr.Add( s.Replace(s, "(" + s + ")"));
                else 
                    newArr.Add(s);
                h++;
            }
            newArr.Insert(0, "(");
            newArr.Insert(newArr.Count , ")");
