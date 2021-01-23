            Product p = new Product();
            p.Cycle.Type = "whatever";
            Item i = new Item();
            i.Artifacts.Add(new Artifact{Kind = 45});
            p.Updates.Items.Add(i);
            Console.WriteLine(SerializeMe(p));
            Console.ReadLine();
