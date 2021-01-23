    public abstract class Entity
    {
        internal abstract void OnSaved();
    }
    class Class1 : Entity
    {
        public static event Action Saved = () => { };
        internal override void OnSaved()
        {
            this.Saved();
        }
        
        //Stuff
    }
    class Class2 : Entity
    {
        public static event Action Saved = () => { };
        
        internal override void OnSaved()
        {
            this.Saved();
        }
        
        //Stuff
    }
