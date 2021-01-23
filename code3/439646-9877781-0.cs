    // Marking the properties as virtual allow you to override their behaviour 'by design'. Their normal
    // behaviour will continue to work if you choose not to
    public abstract class Character
    {
         protected virtual Point Position { get;set; }
         protected virtual int Direction {get;set; }
         protected virtual Image Texture { get;set; }
         protected virtual bool Visible { get; set; }
    
         // Define methods you would like to partially implement or let the other class do:
         public virtual void Rotate(int directionInDegrees)
         {
              this.Direction += directionInDegrees;
         }
    
         public abstract void Draw();
    } 
    
    // Then use inheritance to create the classes based on this
    public class Player : Character
    {
         public override void Rotate(int directionInDegrees)
         {
              // Implement character specific rotate
         }
    
         public void Draw()
         {
              // Must implement Draw(), so that we can instantiate the class properly.
              // All methods of an abstract class must be implemented before a class is deemed
              // valid to use instantiate directly.
         }
    }
    
    public class Enemy : Character
    {
       public override void Rotate()
       {
       }
    }
