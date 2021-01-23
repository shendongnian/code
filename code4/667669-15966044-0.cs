    abstract class SomeBase
    {
      abstract string Name { get; }
    }
    class ImplA : SomeBase{ override string Name { get { return "ImplA"; } } }
    class ImplB : SomeBase{ override string Name { get { return "ImplB"; } } }
    void HiThere(SomeBase input)
    {
        Console.WriteLine(input.Name);
    }
