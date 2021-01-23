    public static void AddObject(object poco)
        {
            using (var eo = new MyEntities())
            {
                        eo.UserRoles.Attach(targetRole); //<-- the magic
                        eo.AddObject("Users", poco);
                        eo.SaveChanges();  //<--- it works like a charm. Hoorah
            }
        }
