       for (Country co in session.Query<Country>()) {
            Console.WriteLine(co);
            Console.Indentation++;
            for (Category ca in session.Query<Category>().Where(x => x.Country.equals(co))) {
                Console.WriteLine(ca);
                //snip
            }
            Console.Indentation--;
        }
