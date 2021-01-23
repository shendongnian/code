    public class AllProperties : InjectionMember
    {
      private readonly List<InjectionProperty> properties;
      public AllProperties()
      {
        this.properties = new List<InjectionProperty>();
      }
      public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
      {
        if(implementationType == null)throw new ArgumentNullException("implementationType");
        // get all properties that have a setter and are not indexers
        var settableProperties = implementationType
          .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
          .Where(pi => pi.CanWrite && pi.GetSetMethod(false) != null && pi.GetIndexParameters().Length == 0);
        // let the Unity infrastructure do the heavy lifting for you
        foreach (PropertyInfo property in settableProperties)
        {
          this.properties.Add(new InjectionProperty(property.Name));
        }
        this.properties.ForEach(p => p.AddPolicies(serviceType, implementationType, name, policies));
      }
    }
