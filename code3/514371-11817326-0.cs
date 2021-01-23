        public string validate(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c.ToString(), "");
            if (name.Length > 31)
                name = name.Substring(0, 31);
            return name;
        }
