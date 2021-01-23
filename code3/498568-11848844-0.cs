    public void Get<TAttribute>(object obj, bool inherit) where TAttribute : System.Attribute
    {
         var ForeignKeyCollection = typeof(ClassName).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttributes(typeof(TAttribute), true).Any())
                    .Select(p => new
                                     {
                                         Property = p,
                                         Attribute = (AssociationAttribute)Attribute.GetCustomAttribute(p, typeof(TAttribute), true)
                                     })
                    .Where(p => p.Attribute.IsForeignKey).ToList();
    }
