    class Example
    {
        int oldField;
        [Obsolete("This is obsolete")]
        public int OldField
        {
            get
            {
                return this.oldField;
            }
            set
            {
                this.oldField = value;
            }
        }
        public int NewField
        {
            get
            {
                return this.oldField;
            }
            set
            {
                this.oldField = value;
            }
        }
    }
