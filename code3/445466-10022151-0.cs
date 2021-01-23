    struct Departments
        {
            public string Department;
            private double[] _buys;
            public double[] Buys
            {
                get { return _buys; }
                set
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] > 100)
                        {
                            if (Department == "CLOTH")
                                _buys[i] = value[i] * .95; if (Department == "FOOD")
                                _buys[i] = value[i] * .90; if (Department == "OTHER")
                                _buys[i] = value[i] * .97;
                        }
                    }
                    _buys = value;
                }
            }
        }
