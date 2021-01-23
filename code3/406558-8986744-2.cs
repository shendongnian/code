    List<Animal> animals = new List<Animal>();
    animals.Add(new Animal("Coco"));
    animals.Add(cat);
    
    foreach(Animal animal in animals)
    {
        Console.WriteLine(String.Format("Name: {0}", animal.Name));
        if(animal is Cat)
        {
            Console.WriteLine(String.Format("{0} is a Cat with {1} teeth.", animal.Name
                (animal as Cat).Teeth));
        }
        Console.WriteLine("============");
    }
