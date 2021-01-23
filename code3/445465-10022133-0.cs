    class Program
    {
        class Department
        {
            public string Name;
            public double Discount;
            private List<double> _buys = new List<double>();
    
            public List<double> Buys
            {
                get { return _buys; }
            }
            public void AddBuy(double value)
            {
                _buys.Add(value > 100 ? value * discount : value);
            }
        }
    
        static void Main()
        {
            var departments = new List<Department>();
            departments.Add(new Department { Name = "CLOTH", Discount = 0.95 });
            departments.Add(new Department { Name = "FOOD", Discount = 0.90 });
            departments.Add(new Department { Name = "OTHER", Discount = 0.97 });
            departments[0].AddBuy(105);
            Console.WriteLine(departments[0].Buys[0]);
        }
    }
