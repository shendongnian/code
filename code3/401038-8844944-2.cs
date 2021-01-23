        public int TestValue {get; set; }
        public byte TestValueAsByte
        {
            get
            {
                if (this.TestValue < 0)
                {
                    return 0;
                }
                else
                {
                    return (byte)this.TestValue;
                }
            }
            set
            {
                this.TestValue = value;
            }
        }
