    public class MyProvider: Provider<IWeapon>
    {
        protected override IWeaponCreateInstance(IContext context)
        {
            if (context.Request.Target.Type == typeof(Samurai))
            {
                 return new Katana();
            }
            if (typeof(IHorseman).IsAssignableFrom(context.Request.Target.Type))
            {
                 return Kernel.Get<IHorsemanWeapon>();
            }
            return new Sword;
        }
    }
