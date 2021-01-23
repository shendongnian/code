    for (Country co in session.Query<Country>()) {
        Console.WriteLine(co); //Possibly c.Name or whatever
        Console.Indentation++; //.NET has not such a method but you understand what it means
        for (Category ca in co.Categories) {
            Console.WriteLine(ca);
            Console.Indentation++;
            for (Store s in ca.Stores) {
                Console.WriteLine(s);
            }
            Console.Indentation--;
        }
        Console.Indentation--;
    }
