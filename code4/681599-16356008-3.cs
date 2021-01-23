    object o = ".NET Framework";
    object o1 = ".NET Framework";
    object o2 = new string(".NET Framework".ToCharArray());
    Console.WriteLine(o == o1);
    Console.WriteLine(o.Equals(o1));
    Console.WriteLine(Object.ReferenceEquals(o,o1)); //True
    Console.WriteLine(Object.ReferenceEquals(o, o2)); //False
