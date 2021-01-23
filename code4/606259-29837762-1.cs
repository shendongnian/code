    public string Name {get;set;}
    public static List<Class> GetList(Expression<Func<Class, bool>> predicate)
        {
            List<Class> c = new List<Class>();
            c.Add(new Class("name1"));
            c.Add(new Class("name2"));
          
            var f = from g in c.
                    Where (predicate.Compile())
                    select g;
            f.ToList();
           return f;
        }
