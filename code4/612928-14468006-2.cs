    using System;
    using System.IO;
    using System.Reflection;
    
    class Mymemberinfo
    {
        public static void Main()
        {
            // Whatever kind of control you are using:
            Object l_control = new Object();
            Console.WriteLine ("\nReflection.MemberInfo");
            // Gets the Type and MemberInfo.
            // ----- Call l_control.GetType();
            Type MyType = l_control.GetType();
            MemberInfo[] Mymemberinfoarray = MyType.GetMembers();
            // Gets and displays the DeclaringType method.
            Console.WriteLine("\nThere are {0} members in {1}.",
                Mymemberinfoarray.Length, MyType.FullName);
            Console.WriteLine("{0}.", MyType.FullName);
            if (MyType.IsPublic)
            {
                Console.WriteLine("{0} is public.", MyType.FullName);
            }
        }
    }
