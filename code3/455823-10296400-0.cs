    public class GameObject 
    {
        public virtual void SetPosition()
        {
           //do something here 
        }
    }
    
    
    public class Derived: GameObject
    {
        public override void SetPosition()
        {
           // do something specific to Derived
           base.SetPosition(); // CALL BASE CLASS METHOD AFTER
        }
    }
