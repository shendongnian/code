    public class SuperModifierClass
    {
        DataHolder dataHolder;
        public SuperModifierClass()
        {
            dataHolder = Process.DataHolder;
        }
    }
    public class FirstModifier
    {
        public FirstModifier() : base() // Is base called implicitly by default? I forgot...
        {
        }
    }
