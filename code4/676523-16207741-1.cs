    using System;
    internal class AClass
    {
        public AClass(int integer)
            : Integer(integer)
        {  }
        
        int Integer { get; set; }
    }
    internal static class StaticFunctions
    {
        public static void FunctionTakingAReference(AClass item)
        {
            item.Integer = 4;
        }
        
        public static void FunctionTakingAReferenceToAReference(ref AClass item)
        {
            item = new AClass(1729);
        }
    }
    public static class Program
    {
        public static void main()
        {
            AClass instanceOne = new AClass(6);
            StaticFunctions.FunctionTakingAReference(instanceOne);
            Console.WriteLine(instanceOne.Integer);
            
            AClass instanceTwo  = new AClass(1234);
            StaticFunctions.FunctionTakingAReferenceToAReference(ref instanceTwo);
            Console.WriteLine(instanceTwo.Integer);
        }
    }
