    Assembly.GetExecutingAssembly()
       .GetTypes()
       .Where(t => t.IsClass && t.Namespace == "Your.Name.Space")
       .ToList()
       .ForEach(t => ModelBinders.Binders[t] = new NonValidatingModelBinder());
