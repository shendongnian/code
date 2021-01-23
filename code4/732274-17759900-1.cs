    class Program : Person
    {
        static List<Person> persons = new List<Person>();
        static void Main(string[] args)
        {
            
            Person Luke = new Person();
            Luke.Update("Luke", 15);
            Console.WriteLine(Luke.ToString());
            Person Daniel = new Person();
            Daniel.Update("Daniel", 14, "Jones");
            Console.WriteLine(Daniel.ToString());
            Person Aimee = new Person();
            Aimee.Update("Aimee", 18, "Jones");
            Console.WriteLine(Aimee.ToString());
            Person Will = new Person();
            Will.Update("William", 22, "Rae");
            Console.WriteLine(Will.ToString());
            persons.Add(Luke);
            persons.Add(Daniel );
            persons.Add(Aimee );
            persons.Add(Will );
            var founded = FindPersonById("xxx-x-xxxxx");
            Console.ReadLine();
        }  
        static Person FindPersonById(int Id)
        {
            return persons.FirstOrDefault(p => p.ID == Id);
        }
    }
