            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("ABC", 2);
            dict.Add("CDE", 3);
            dict.Add("FGH", 4);
            dict.Add("JKL", 5);
            string Numbers = "BDJ";
            string myints = "";
            foreach (char c in Numbers)
                myints += dict.FirstOrDefault(X => X.Key.Contains(c)).Value.ToString();
    //the output : "235"
