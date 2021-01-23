    public interface ITest
    {
        void M1();
        string M2(int m2, string n2);
    }
    ...
    ITest it = GenerateInterfaceImplementation<ITest>(
        new Action(() => { Console.WriteLine("called");  return; }),
        new Func<int, string, string> ((i, s) => s + i.ToString()));
    it.M1();
    Console.WriteLine(it.M2(6, "You are number "));
