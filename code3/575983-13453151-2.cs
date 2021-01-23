            char[] Removechars = new[] { '#', '*' };
            Console.WriteLine("Join+Where");
            Test(s => String.Join("", s.Where(c => !Removechars.Contains(c))), str);
            Console.WriteLine("ArrayOperation");
            Test(s => new string(Array.FindAll(s.ToCharArray(), c => !Removechars.Contains(c))), str);
            Console.WriteLine("Except");
            Test(s => new string(s.ToCharArray().Except(Removechars).ToArray()), str);
            
            Console.WriteLine("Join+Select");
            Test(s => string.Join("", s.Select(c => !Removechars.Contains(c) ? c.ToString():"")), str);
