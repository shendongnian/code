    static void print<T>(T o) {
        //Not a collection
    }
    static void print<T>(IEnumerable<T> o) {
       foreach(var i in o2) {
            Console.WriteLine(i);
       }
    }
