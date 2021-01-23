    using System;
    using System.ComponentModel;
    namespace ConsoleApplication1
    {
        public enum ControlDefaultClass
        {
            [Description("This is some string which you wanted to show")] MemberA,
            [Description("This is some other string which you wanted to show")] MemberB,
        }
    
        public class ConsoleApp
        {
            private static void Main(string[] args)
            {
                Console.WriteLine(GetDescription(ControlDefaultClass.MemberA));  //This line will print - This is some string which you wanted to show
                Console.WriteLine(GetDescription(ControlDefaultClass.MemberB));//This line will print - This is some other string which you wanted to show
                Console.Read();
            }
    
            public static string GetDescription(Enum value)
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var attributes =
                    (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
        }
    }
