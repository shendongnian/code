            var pattern =
    @"/+File description/+ 
    Name: (?<name>.+) 
    Size: (?<size>.+) 
    Description: (?<des>.+) 
    Date: (?<date>.+) 
    /+";
            var temp = Regex.Replace(data, pattern, new MatchEvaluator(eval));
            Console.WriteLine("{0}", temp);
        //...
        string eval(Match mx)
        {
            StringBuilder sb = new StringBuilder();
            Stack<Group> stk = new Stack<Group>();
            for(int i=1; i<mx.Groups.Count; ++i)
                stk.Push(mx.Groups[i]);
            
            string result = mx.Groups[0].Value;
            int offt = mx.Index;
            while(stk.Count > 0)
            {
                var g = stk.Pop();
                int index = g.Index - offt;
                result = result.Substring(0,index) + result.Substring(index+g.Length);
            }
            return result;
        }
