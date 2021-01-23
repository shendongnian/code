    public class CommandsHandlersModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterAssemblyTypes(typeof(CartCommandsHandler).Assembly)
           .AsClosedTypesOf(typeof(IHandleCommand<>))
           .SingleInstance();
       }
    }
