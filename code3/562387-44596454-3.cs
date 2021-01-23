    public class MyClass
    {
        public enum MyEnum { [Display(Name="ONE")]One, Two }
        public void UseMyEnums()
        {
            MyEnum foo = MyEnum.One;
            MyEnum bar = MyEnum.Two;
            Console.WriteLine(foo.GetDisplayName());
            Console.WriteLine(bar.GetDisplayName());
        }
    }
    // Output:
    //
    // ONE
    // Two
