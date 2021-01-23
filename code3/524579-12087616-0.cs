     string text = "AB12(100).HJI(20).D76R(222)";
     MatchCollection match = Regex.Matches(text, @"\(\d+\)"); //(100)(20)(222)
     string[] digits = new string[match.Count];
            
     for(int i=0; i<digits.Length;i++)
     {
         digits[i] = match[i].Value.Trim(new char[]{'(',')'});
     }
     string output = String.Join(".", digits); //100.20.222
