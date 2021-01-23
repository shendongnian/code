        public int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>();
            dict['I'] = 1;
            dict['V'] = 5;
            dict['X'] = 10;
            dict['L'] = 50;
            dict['C'] = 100;
            dict['D'] = 500;
            dict['M'] = 1000;
            Stack<char> st = new Stack<char>();
            foreach (char ch in s.ToCharArray())
                st.Push(ch);
            int result = 0;
            while (st.Count > 0)
            {
                var c1=st.Pop();
                var ch1 = dict[c1];
                if (st.Count > 0)
                {
                    var c2 = st.Peek();
                    var ch2 = dict[c2];
                    if (ch2 < ch1)
                    {
                        result += (ch1 - ch2);
                        st.Pop();
                    }
                    else
                    {
                        result += ch1;
                    }
                }
                else
                {
                    result += ch1;
                }
            }
            return result;
        }
