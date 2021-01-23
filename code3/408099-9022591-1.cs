    public class WarriorModule : NinjectModule {
        public override void Load() {
          Bind<ISomeTypeService>().To<SomeTypeService>();
        }
    }
    
    public class TestingWarriorModule : NinjectModule {
        public override void Load() {
          Bind<ISomeTypeService>().To<SomeTestingTypeService>();
        }
    }
