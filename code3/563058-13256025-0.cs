           Id(x => x.Id,
           m =>
           {
               m.Generator(Generators.Assigned);
               m.Type((IIdentifierType)TypeFactory.GetAnsiStringType(16));
               m.Length(16);
           });
