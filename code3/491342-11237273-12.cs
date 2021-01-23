            using (var context = new CompanyDbContext())
            {
                var repo = new UserRepository(context);
                var list = repo.Find(a=>a.Id >= 2).ToList();
                list.ForEach(a => Console.WriteLine("Id: {0}, Name {1}, email {2}", a.Id, a.Name, a.Email));
            }
