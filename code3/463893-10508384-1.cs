        private string sample;
        public  string Sample
        {
            get
            {
                return (sample = sample ?? SomeExpensiveMethod());
            }
        }
