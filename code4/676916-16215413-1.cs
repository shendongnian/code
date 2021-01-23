    class Dog : Animal
    {
       public Dog(Animal a)
       {
          this.Name = a.Name;
          this.Id = a.Id;
       }
    
       public void sniffBum()
       {
           Console.WriteLine("sniff sniff sniff");
       }
    }
