    public static void Main()
    {
        Person me = new Person();
        Object you = new Object();
        // you as person = null
        me = you as Person;
        //me = (Person) you;
        System.Console.WriteLine("Type: {0}", me.GetType()); //This line throws exception
    }
