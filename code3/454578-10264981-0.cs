    class A
    {
        public int A { get; set; }
        public string B { get; set; }
        public float C { get; set; }
        public string[] concatFields()
        {
            var v = from f in this.GetType().GetFields() select f;
            IList<string> fields = new List<string>();
            foreach (var f in v)
            {
                fields.Add(f.GetValue(this).ToString());
            }
            return fields.ToArray<string>();
        }
    }
