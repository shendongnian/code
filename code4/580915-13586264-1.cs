    public class MyModule : Module {
       protected override void Load(ContainerBuilder builder){
          builder.RegisterType<MyDependency>().As<IMyDependency>().InstancePerDependency();
       }
    }
