    class Buys
    {
        private double[] _buys;
        public Buys (int capacity)
        {
            _buys = new double[capacity];
        }
        public double this[int index]
        {
            get { return _buys; }
            set 
            {
                if (value > 100)
                {
                    if (Department == "CLOTH")
                        value = value * .95;
                    if (Department == "FOOD")
                        value = value * .90;
                    if (Department == "OTHER")
                        value = value * .97;
                }
                _buys = value;
            }
        }
    }
    struct Departments
    {
        public string Department;
        public Buys Buys;
    }
    static void Main()
    {
        var departments = new Departments[3];
        departments[0].Department = "CLOTH";
        departments[1].Department = "FOOD";
        departments[2].Department = "OTHER";
        departments[0].Buys = new Buys(5);
        departments[0].Buys[0] = 105;
    }
