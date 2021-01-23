    using System;
    using System.Reflection;
    using System.Windows.Documents;
    
    namespace ReflectionWpfListPropertiesTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var members = typeof(List).GetMembers();
    
                Array.ForEach(members, info =>
                    {
                        if (info.MemberType == MemberTypes.Property)
                            Console.WriteLine(info);
                    });
            }
        }
    }
