    unsafe String Reverse(String s)
            {
                char[] sarr = new char[s.Length];
                fixed (char* c = s)
                fixed (char* d = sarr)
                {
                    char* c1 = c;
                    char* d1 = d + s.Length;
                    while (d1 > d)
                    {
                        *--d1 = *c1++;
                    }
                }
    
                return new String(sarr);
            }
