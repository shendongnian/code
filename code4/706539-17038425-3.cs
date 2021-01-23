            using(var ctx = new UsersContext())
            {
                SomeEntity s = new SomeEntity();
                s.SomeByteWrapper = 123861234123;
                ctx.SomeEntities.Add(s);
                ctx.SaveChanges();
            }
