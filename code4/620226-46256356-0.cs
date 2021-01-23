    public class test{
    public string Name{ get; set; }
    }
    var prop = now DeepCloner.GetFastDeepClonerProperties(typeof(test)).First();
    prop.Attributes.Add(new JsonIgnoreAttribute());
    // now test and se if exist 
    prop = now DeepCloner.GetFastDeepClonerProperties(typeof(test)).First();
    var containAttr = prop.ContainAttribute<JsonIgnoreAttribute>()
    // or 
    var myAttr = prop.GetCustomAttribute<JsonIgnoreAttribute>();
