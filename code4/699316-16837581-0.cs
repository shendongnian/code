            public int datavalue2
            {
                get
                {
                    return mydatavalue2;
                }
                set{
                    mydatavalue2 = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs(
                            "datavalue2"));
                    }
                }
            }
