    DateTime young = DateTime.MinValue;
    DateTime old   = DateTime.MaxValue;
    foreach (var d in students)
    {
     DateTime dt = Convert.ToDateTime(d.dob);
     old = old < dt ? old : dt;
     young = young > dt ? young : dt;
    }
     Console.WriteLine("the youngest age is {0}", young);
     Console.WriteLine("the oldest age is {0}", old);
