    public bool ContainsUnicodeCharacter(char[] input)
        {
            const int MaxAnsiCode = 255;
            bool temp;
            string s;
    
            foreach (char a in input)
            {
                s = a.ToString();
                temp = s.Any(c => c > MaxAnsiCode);
                if (temp == false)
                {
                   return false;
                 }
            } 
             return true;  
        }
