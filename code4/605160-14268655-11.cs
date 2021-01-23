    class Fireball
    {
       public override void Activate()
       {
           //do fireball specific things
           this.FireTheFireBall();
       }   
       public void FireTheFireBall() {...}    
    }
    class Heal
    {
       public override void Activate()
       {
           //do healing specific things
           this.ApplyTheBandage();
       }
       ...
    }
    
    abstract class Ability
    {
      public abstract void Activate();
    }
    void condition(Ability f){
       f.Activate(); //runs the version of Activate of the derived class
    }
    
