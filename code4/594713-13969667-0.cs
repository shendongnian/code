            var person = new { Name = "" }; ;
            if (cond1)
            {
                person  = new { Name = "Bob" };
            }
            else
            {
                person  = new { Name = "John" };
            }
            Console.WriteLine(person.Name);
