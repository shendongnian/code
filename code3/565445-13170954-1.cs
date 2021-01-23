            SortedSet<Person> list = new SortedSet<Person>(new PersonComparer());
            list.Add(new Person { Name = "aby", Age = "1" });
            list.Add(new Person { Name = "aab", Age = "2" });
            foreach (Person p in list)
                Console.WriteLine(p.Name);
