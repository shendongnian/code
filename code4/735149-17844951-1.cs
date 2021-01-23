        public string zip(string s1, string s2)
        {
            return (string.IsNullOrWhiteSpace(s1+s2))
                ? (s1[0] + "" + s2[0] + zip(s1.Substring(1) + " ", s2.Substring(1) + " ")).Replace(" ", null)
                : "";
        }
         
        var result =  zip("mark","zukerberg");
