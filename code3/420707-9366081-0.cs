    public class FieldDesc
    {
        public FieldDesc()
        {
        }
        public void A()
        {
        }
        public virtual void V()
        {
            Console.WriteLine("V from FieldDesc");
        }
    }
    public class StandardHoursByCommunitySvcType : FieldDesc
    {
        public StandardHoursByCommunitySvcType()
        {
        }
        public void B()
        {
        }
        public overrides void V()
        {
            Console.WriteLine("V from StandardHoursByCommunitySvcType");
        }
    }
