        public static string integerToString(int integerPassedIn)
        {
            if (integerPassedIn == 0) return "0";
            var negative = integerPassedIn < 0;
            var res = new List<char>();
            while(integerPassedIn != 0)
            {
               res.Add((char)(48 + Math.Abs(integerPassedIn % 10)));
               integerPassedIn /= 10;
            }
            res.Reverse();
            if (negative) res.Insert(0, '-');
            return new string(res.ToArray());
        }
