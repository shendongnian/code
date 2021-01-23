    public Class
    {
        public string variable;
        public List<AnotherClass> listVariable;
    
        public void Print()
        {
            foreach(var item in listVariable)
            {
               // ...or how you what to print?
               Console.WriteLine(item.GetString());
            }
        }
    }
    
    public AnotherClass
    {
        public string variable;
        public int intVariable;
    
        public string GetString()
        {
            // Format here your output.
            return String.Format("Var: {0}, IntVar: {1}", this.variable, this.intVariable);
        }
    }
