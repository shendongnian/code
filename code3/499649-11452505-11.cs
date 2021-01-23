    public interface ITest
    {
        void M1();
        string M2(int m2, string n2);
        string P { get; set; }
    }
    ...
    var iType = GenerateInterfaceImplementator<ITest>();
    var instance = (ITest)Activator.CreateInstance(iType,
        new Action(() => { Console.WriteLine("M1 called");  return; }),
        new Func<int, string, string>((ij, xjx) => xjx + ij.ToString()),
        new Func<String>(() => "P getter called"),
        new Action<string>(s => { Console.WriteLine(s); }));
    instance.M1();
    Console.WriteLine(instance.M2(6, "you are number "));
    instance.P = "P setter called";
    Console.WriteLine(instance.P);
