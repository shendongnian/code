    abstract class MovementStrategy
    {
        public abstract void Move();
        public abstract void ChangePosition(Direction d);    
    }
    class PlayerMovementStrategy
    {
        public override void Move()
        {
            //move
        }
        public override void ChangePosition(Direction d)
        {
            //change position
        }
    }
    abstract class VisibilityStrategy
    {
        public abstract void Disappear();
    }
    class PlayerVisibilityStrategy
    {
        public void Disappear()
        {
            //poof 
        }
    }
    class Player
    {
         private readonly PlayerMovementStrategy movement;
         private readonly PlayerVisibilityStrategy visibility;
         public Player(PlayerMovementStrategy movement, PlayerVisibilityStrategy visibility)
         {
             this.movement = movement;
             this.visibility = visibility;
         }
         public void Disappear()
         {
             visibility.Disappear();
         }         
         public void Move(Direction d)
         {
             movement.Move(d);
         }
    }
