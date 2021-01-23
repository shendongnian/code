       // Creates and initializes a one-dimensional array.
        MyClass[] stripe = new MyClass[5];
        // Sets the element at index 3.
        stripe.SetValue(new MyClass() { Name = "three" }, 3);
            
        // Creates and initializes a two-dimensional array.
        MyClass[,] arr = new MyClass[5, 5];
        // Sets the element at index 1,3.
        arr.SetValue(stripe[3], 1, 3);
        Console.WriteLine("[1,3]:   {0}", arr.GetValue(1, 3));
