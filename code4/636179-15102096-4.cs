        static Random rdm = new Random();
        public string[] Shuffle(string[] c)
        {
            var random = rdm;
            for (int i = c.Length; i > 1; i--)
            {
                int iRdm = rdm.Next(i);
                string cTemp = c[iRdm];
                c[iRdm] = c[i - 1];
                c[i - 1] = cTemp;
            }
            return c;
        }
