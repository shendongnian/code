    struct MyStruct
    {
                public string name;
                public double amount;
    }
    Products[] p1 = new Products[] { new Products { name = "prod1", amount = 5 }
    var c = from p in p1
            select new MyStruct { name = p.name, amount = p.amount };
