    public class A { }
    public class B : A { }
    public static class DescriptionHelpers
    {
        public static string GetDescription(this A inst)
        {
            return "Foo";
        }
        public static string GetDescription(this B inst)
        {
            return "Bar";
        }
    }
