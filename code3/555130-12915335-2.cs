    class Foo
    {
        private string pk;
    
        public string PK
        {
            get
            {
                return this.pk;
            }
            set
            {
                if(Enum.IsDefined(typeof(ContentKey), value))
                {
                    this.pk = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
