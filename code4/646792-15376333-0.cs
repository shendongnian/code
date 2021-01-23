    public class Person
    {
    }
    public class Organization
    {
    }
    
    class Program
    {
        // Generate a Person if i == true or Organization if i == false
        static object GetPersonOrOrganization(bool i)
        {
            if (i == true)
            {
                return new Person();
            }
            else
            {
                return new Organization();
            }
        }
    
        static void Main(string[] args)
        {
            var p = GetPersonOrOrganization(true); // Generates a Person.
    
            if (p.GetType() == typeof(Person))
            {
                Console.WriteLine("Person!"); // This prints.
            }
            else
            {
                Console.WriteLine("Organization");
            }
    
            var o = GetPersonOrOrganization(false); // Generates an Organization.
    
            if (o.GetType() == typeof(Person))
            {
                Console.WriteLine("Person!");
            }
            else
            {
                Console.WriteLine("Organization!"); // This prints.
            }
    
            Console.ReadLine();
        }
    }
