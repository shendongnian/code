    class Class1
    {
        private Dictionary<String, Boolean> boolenVars = new Dictionary<String, Boolean>();
        public Boolean getFlag(String key)
        {
            if (this.boolenVars.ContainsKey(key))
                return this.boolenVars[key];
            else
                return false;
        }
        public void setFlag(String key, Boolean value)
        {
            if (this.boolenVars.ContainsKey(key))
                this.boolenVars[key] = value;
            else
                this.boolenVars.Add(key, value);
        }
        public void clearFlags()
        {
            this.boolenVars.Clear();
        }
    }
