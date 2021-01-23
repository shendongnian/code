    class P
    {
        class Animal {}
        class Tiger : Animal {}
        static void M<T> (Animal animal) where T : Animal
        {
            T t = animal as T;
            System.Console.WriteLine(t == null);
        }
        static void Main ()
        {
           Animal animal = new Tiger();
           M<Tiger>(animal);
        }
    }
