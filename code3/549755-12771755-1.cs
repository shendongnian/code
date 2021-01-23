            var returned = new List<int> { 4, 5, 8 };
            var listint = new List<int>() { 1, 2, 3, 4 };
            var incoming = returned.Select(s => s);       //
            if (incoming.All(listint.Contains))
            {
                Console.WriteLine("if1");
            }
            if (incoming.Any(listint.Contains) && !incoming.All(listint.Contains))
            {
                //dosomething
                Console.WriteLine("if2");
            }
