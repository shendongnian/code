    public sealed class Synonyms: Attribute
    {
        private readonly string[] values;
    
        public AbbreviationAttribute(params string[] i_Values)
        {
            this.values = i_Values;
        }
    
        public string Values
        {
            get { return this.values; }
        }
    }
