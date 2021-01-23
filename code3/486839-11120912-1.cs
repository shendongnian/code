        List<Person> liste = new List<Person>();
        liste.Add(new Person { FirstName = "AAA", LastName = "BBBB" });
        liste.Add(new Person { FirstName = string.Empty, LastName = null });
        liste.Add(new Person { FirstName = "CCC", LastName = "DDD" });
        InsertList(liste);
