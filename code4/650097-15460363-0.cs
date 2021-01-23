            Dog dog = new Dog("Bowser");
            WeakReference dogRef = new WeakReference(dog);
            Console.WriteLine(dogRef.IsAlive);
            dog = null;
            GC.Collect();
            Console.WriteLine(dogRef.IsAlive);
