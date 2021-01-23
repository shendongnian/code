    // using System.Linq;
    // using System.Reflection;
    // using System.Runtime.Serialization;
    obj.GetType()
       .GetProperties(…)
       .Where(p => Attribute.IsDefined(p, typeof(DataMemberAttribute)))
       .Single(p => ((DataMemberAttribute)Attribute.GetCustomAttribute(
                        p, typeof(DataMemberAttribute))).Name == "Foo");
