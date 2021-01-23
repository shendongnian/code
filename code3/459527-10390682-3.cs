    public void Run()
    {
        Dog myDog = new Dog();
        myDog.Name= "Foo";
        myDog.Color = DogColor.Brown;
        System.Console.WriteLine("{0}", myDog.ToString());
        MemoryStream stream = SerializeToStream(myDog);
        Dog newDog = (Dog)DeserializeFromStream(stream);
        System.Console.WriteLine("{0}", newDog.ToString());
    }
    
