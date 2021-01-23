    //note: abstract is not a pre-requisite for inheritance
    abstract class Character
    {
         protected float x;
         protected float y;
         protected float z;
         //etc etc
    }
    public class AIBasic : Character
    {
        public void move()
        {
             //purely an example
             base.x++;
             base.y++;
             base.z++;
        }
    }
