    var b1 = context.Bs.Find(1);
    var b2 = context.Bs.Find(2);
    var a = new A
    {
        A_Bs = new List<A_B>
        {
            new A_B { B = b1, SortOrder = 1 },
            new A_B { B = b2, SortOrder = 2 }
        }
    };
    context.As.Add(a);
    context.SaveChanges();
