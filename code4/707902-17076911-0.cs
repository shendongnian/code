    private double a;
        public double A
        {
            get { return a; }
            set { a = value;
                  firepropertyChange(a);
                }
        }
