    using System;
    using System.Reflection;
    
    public class PersonalInformation    {
        public string FirstName { get; set; }
        public string FirstSomethingElse { get; set; }
    }
    
    public class Foo 
    {
        public PersonalInformation PersonalInformation { get; set; }
        
        public void ShowProperties()
        {
            foreach (var property in this.PersonalInformation
                                         .GetType()
                                         .GetProperties())
            {
                var value = property.GetValue(this.PersonalInformation, null);
                Console.WriteLine("{0}: {1}", property.Name, value);
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            Foo foo = new Foo { 
                PersonalInformation = new PersonalInformation {
                    FirstName = "Fred",
                    FirstSomethingElse = "XYZ"
                }
            };
            foo.ShowProperties();
        }
    }
