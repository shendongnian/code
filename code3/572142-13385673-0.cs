    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Example1
    {
        class Program
        {
            class Human
            {
                public string Name { get; set; }
                public string Hobby { get; set; }
                public DateTime DateOfBirth { get; set; }
            }
            class Animal
            {
                public string Name { get; set; }
                public string FavouriteFood { get; set; }
                public DateTime DateOfBirth { get; set; }
            }
    
            static void Main(string[] args)
            {
                var humans = new List<Human>
                {
                    new Human
                    {
                        Name = "Kate",
                        Hobby = "Fitness",
                        DateOfBirth = DateTime.Now.AddYears(-27),
                    },
                    new Human
                    {
                        Name = "John",
                        Hobby = "Cars",
                        DateOfBirth = DateTime.Now.AddYears(-32),
                    },
                };
    
                var animals = new List<Animal>
                {
                    new Animal
                    {
                        Name = "Fluffy",
                        FavouriteFood = "Grain",
                        DateOfBirth = DateTime.Now.AddYears(-2),
                    },
                    new Animal
                    {
                        Name = "Bongo",
                        FavouriteFood = "Beef",
                        DateOfBirth = DateTime.Now.AddYears(-6),
                    },
                };
    
                var customCollection = (from human in humans
                                        select new
                                            {
                                                Name = human.Name,
                                                Date = human.DateOfBirth,
                                            }
                                            ).Union(from animal in animals
                                                    select new
                                                        {
                                                            Name = animal.Name,
                                                            Date = animal.DateOfBirth,
                                                        }).OrderBy(x => x.Date);
    
    
                foreach (dynamic customItem in customCollection)
                    Console.WriteLine(String.Format("Date: {0}, Name: {1}",      customItem.Date, customItem.Name));
                Console.Read();
            }
        }
    }
