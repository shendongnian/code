    using System;
    namespace StackOverflow.Demos
    {
        
        class Program
        {
            public static void Main(string[] args)
            {
                new Program();
                Console.ReadKey();
            }
            private Program()
            {
                Type type = GetPersonOrOrganisation(new Person());
                object myInstance = GetInstanceOfType(type);
                Console.WriteLine(myInstance.ToString());
                type = GetPersonOrOrganisation(new Organization());
                myInstance = GetInstanceOfType(type);
                Console.WriteLine(myInstance.ToString());
            }
            private Type GetPersonOrOrganisation(object what)
            {
                return what.GetType();
            }
            private object GetInstanceOfType(Type type)
            {
                return type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
        }
        public class Person
        {
            public Person() { }
        }
        public class Organization
        {
            public Organization() { }
        }
    }
