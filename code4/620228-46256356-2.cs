    public class test{
    public string Name{ get; set; }
    }
    var prop = DeepCloner.GetFastDeepClonerProperties(typeof(test)).First();
    prop.Attributes.Add(new JsonIgnoreAttribute());
    // now test and se if exist 
    prop = DeepCloner.GetFastDeepClonerProperties(typeof(test)).First();
    bool containAttr = prop.ContainAttribute<JsonIgnoreAttribute>()
    // or 
    JsonIgnoreAttribute myAttr = prop.GetCustomAttribute<JsonIgnoreAttribute>();
