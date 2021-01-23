        public Row(string str)
        {
            Number1 = Convert.ToDouble(str.Substring(4, 6));
            Number2 = Convert.ToDouble(str.Substring(16, 6));
            Number3 = Convert.ToDouble(str.Substring(28, 7));
            Number4 = Convert.ToDouble(str.Substring(40, 7));
            Number5 = Convert.ToDouble(str.Substring(52, 6));
            Number6 = Convert.ToDouble(str.Substring(64, 6));
            Number7 = Convert.ToDouble(str.Substring(76, 6));
            Date1 = str.Substring(88, 24);
        }
