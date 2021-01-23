    public class WarriorModule : NinjectModule
    {
        public override void Load() 
        {
            Bind<IWeapon>().To<Sword>();
            Bind<Samurai>().ToSelf().InSingletonScope();
        }
    }
