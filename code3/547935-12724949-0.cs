    [TestMethod]
    public void TestMethod1()
    {
      var container = new UnityContainer().AddNewExtension<DeduplicateRegistrations>();
      container.RegisterType<IBoth, Both>();
      IThree three = container.Resolve<IThree>();
      Assert.AreEqual("3", three.Three());
    }
    
    public class DeduplicateRegistrations : UnityContainerExtension
    {
      protected override void Initialize()
      {
        this.Context.Registering += OnRegistering;
      }
      private void OnRegistering(object sender, RegisterEventArgs e)
      {
        if (e.TypeFrom.IsInterface)
        {
          Type[] interfaces = e.TypeFrom.GetInterfaces();
          foreach (var @interface in interfaces)
          {
            this.Context.RegisterNamedType(@interface, null);
            if (e.TypeFrom.IsGenericTypeDefinition && e.TypeTo.IsGenericTypeDefinition)
            {
              this.Context.Policies.Set<IBuildKeyMappingPolicy>(
                new GenericTypeBuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo)),
                new NamedTypeBuildKey(@interface, null));
            }
            else
            {
              this.Context.Policies.Set<IBuildKeyMappingPolicy>(
                new BuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo)),
                new NamedTypeBuildKey(@interface, null));
            }
          }
        }
      }
    }
    public class Both : IBoth
    {
      public string One() { return "1"; }
      public string Two() { return "2"; }
      public string Three() { return "3"; }
    }
    public interface IOne : IThree
    {
      string One();
    }
    public interface IThree
    {
      string Three();
    }
    public interface ITwo
    {
      string Two();
    }
    public interface IBoth : IOne, ITwo
    {
    }
