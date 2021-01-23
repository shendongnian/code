    public class SomeTypeOfPlayer : Player
    {
      //protected int moveSpeed = 2; DON'T DO THIS! It would be 
      //re-defining it, not setting the existing field.
      public SomeTypeOfPlayer()
      {
        moveSpeed = 2;  //Do this
      }
    }
