        bool check(string[] a, string s)
        {
            for (int i = 0; i < a.Length; i++)
                if (s == a[i])
                    return true;
            return false;
        }
        public double simi(string string1, string string2)
        {
            int sub1 = 0;
            int sub2 = 0;
            string[] sp1 = new string[string1.Length - 1];
            string[] sp2 = new string[string2.Length - 1];
            string[] sp3 = new string[string1.Length - 1];
            string[] sp4 = new string[string2.Length - 1];
            for (int i = 0; i < string1.Length - 1; i++)
            {
                string x = "";
                x = string1.Substring(i, 2);
                sp1[sub1] = x;
                ++sub1;
            }
            for (int i = 0; i < string2.Length - 1; i++)
            {
                string x = "";
                x = string2.Substring(i, 2);
                sp2[sub2] = x;
                ++sub2;
            }
            int j = 0, k = 0;
            for (int i = 0; i < sp1.Length; i++)
                if (check(sp3, sp1[i]) == true)
                {
                    continue;
                }
                else
                {
                    sp3[j] = sp1[i];
                    j++;
                }
            for (int i = 0; i < sp2.Length; i++)
                if (check(sp4, sp2[i]) == true)
                {
                    continue;
                }
                else
                {
                    sp4[k] = sp2[i];
                    k++;
                }
            Array.Resize(ref sp3, j);
            Array.Resize(ref sp4, k);
            Array.Sort<string>(sp3);
            Array.Sort<string>(sp4);
            int n = 0;
            for (int i = 0; i < sp3.Length; i++)
            {
                if (check(sp4, sp3[i]))
                {
                    n++;
                }
            }
            double resulte;
            int l1 = sp3.Length;
            int l2 = sp4.Length;
            resulte = ((2.0 * Convert.ToDouble(n)) / Convert.ToDouble(l1 + l2)) * 100;
            return resulte;
        }
