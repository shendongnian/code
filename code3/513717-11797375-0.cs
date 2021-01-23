            string user = @"DOMAIN//USER";
            Regex pattern = new Regex("[/]+");
            var sp = pattern.Split(user);
            user = sp[1] + "@" + sp[0];
            Console.WriteLine(user);
