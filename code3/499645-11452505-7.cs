    public interface ITest
    {
        void M1();
        string M2(int m2, string n2);
    }
    ...
    var iType = GenerateInterfaceImplementator<ITest>();
    var instance = (ITest)Activator.CreateInstance(iType,
        new Action(() => { Console.WriteLine("called");  return; }),
        new Func<int, string, string>((ij, xjx) => xjx + ij.ToString()));
    instance.M1();
    Console.WriteLine(instance.M2(6, "you are number "));
