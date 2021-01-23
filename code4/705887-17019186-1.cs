    unsafe String Reverse(String s)
            {
                char[] sarr = new char[s.Length];
                int idx = s.Length;
                fixed (char* c = s)
                {
                    char* c1 = c;
                    while (idx != 0)
                    {
                        sarr[--idx] = *c1++;
                    }
                }
    
                return new String(sarr);
            }
