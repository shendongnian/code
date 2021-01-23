            private DateTime _dt1; 
            public string dt1 { 
                get 
                {
                    return _dt1.ToString(new CultureInfo("nl-NL"));
                } 
                set
                {
                    _dt1 = DateTime.Parse(value);
                }
            }
