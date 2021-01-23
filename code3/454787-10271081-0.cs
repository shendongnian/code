    class Snake {
         int speed;
         public override void Enemy Clone() {
             var clone = new Snake();
             clone.speed = speed;
             return clone;
         }
    }
