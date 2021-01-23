    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            // This lets you add new functionality to the primitive type 'int'
            // Allowing you to do (10).Add(5) to give you a List<int> with {10, 5}
            public static List<int> And( this int num, int other )
            {
                return new List<int> { num, other };
            }
            public static List<int> And( this List<int> num, int other )
            {            
                num.Add(other);
                return num;
            }
        }
    }
    // ===========================================================================
    // And Program.cs
    using ExtensionMethods;
    namespace SyntaxTests
    {
        class Program
        {
            static void Main( string[] args )
            {            
                var nums = (30).And(60).And(90);
                nums.ForEach(n => Console.WriteLine(n + "\n"));
            }
        }
    }
