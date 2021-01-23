    using System;
    using System.Text;
     
    namespace ConsoleApplication1 {
     
        class Program {
     
            public static void Main()  {
                string myString = "1";
                object objectString = "1";
                string myCopiedString = string.Copy(myString);
                string internedString = string.Intern(myCopiedString);
     
                Console.WriteLine(myString); //1
                Console.WriteLine(objectString); //1
                Console.WriteLine(myCopiedString); //1
                Console.WriteLine(internedString); //1
     
                Console.Write(objectString == myString); //true
                Console.Write(objectString == "1"); //true
                Console.Write(objectString == myCopiedString); //!!!FALSE!!!!
                Console.Write(objectString == internedString); //true
                Console.Write(objectString == SomeMethod()); //!!!FALSE!!!
                Console.Write(objectString == SomeOtherMethod()); //true
            }
     
            public static string SomeMethod() {
                StringBuilder sb = new StringBuilder();
                return sb.Append("1").ToString();
            }
     
            public static string SomeOtherMethod() {
                return "1".ToString();
            }        
        }
    }
