    class Program
        {
            class somefields
            {
                public string first;
                public string secound;
                public string Add;
                public int index;
                public somefields(string F, string S)
                {
                    first = F;
                    secound = S;
                }
    
            }
        static void Main(string[] args)
        {
            //declaring output
            string input = "consecuti?vely";
            List<somefields> rules=new List<somefields>();
            //declaring rules
            rules.Add(new somefields("cuti?",@"cuti?(-\s+)?"));
            rules.Add(new somefields("con",@"con(-\s+)?"));
            rules.Add(new somefields("consecu",@"consecu(-\s+)?"));
            // finding the string which must be added to output string and index of that
            foreach (var rul in rules)
            {
                var index=input.IndexOf(rul.first);
                if (index != -1)
                {
                    var add = rul.secound.Remove(0,rul.first.Count());
                    rul.Add = add;
                    rul.index = index+rul.first.Count();
                }
 
            }
            // sort rules by index
            for (int i = 0; i < rules.Count(); i++)
            {
                for (int j = i + 1; j < rules.Count(); j++)
                {
                    if (rules[i].index > rules[j].index)
                    {
                        somefields temp;
                        temp = rules[i];
                        rules[i] = rules[j];
                        rules[j] = temp;
                    }
                }
            }
            string output = input.ToString();
            int k=0;
            foreach(var rul in rules)
            {
                if (rul.index != -1)
                {
                    output = output.Insert(k + rul.index, rul.Add);
                    k += rul.Add.Length;
                }
            }
            System.Console.WriteLine(output);
            System.Console.ReadLine();
        }
    } 
