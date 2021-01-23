    var results = from s in Context.Schools
        ...
        select new MyClassContainingOnlyAFewProperties {
                     Prop1 = s.Prop1,
                     Prop2 = s.Prop2, 
                     //etc.
        }
    return results;
