    string line = "a,b,mc,dm,e,f,mk,lm,g,h";
          
        string result =replacestr(line, 'm', ',', ';');
    
    
        public string replacestr(string line,char seperator,char oldchr,char newchr)
        {
            int cnt = 0;
            StringBuilder b = new StringBuilder();
            foreach (char chr in line)
            {
                if (cnt == 1 && chr == seperator)
                {
                    b[b.ToString().LastIndexOf(oldchr)] = newchr;
                    b.Append(chr);
                    cnt = 0;
                }
                else
                {
                    if (chr == seperator)
                        cnt = 1;
                    b.Append(chr);
                }
            }
            return b.ToString();
        }
