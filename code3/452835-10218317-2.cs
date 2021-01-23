    public class Player
    {
     protected int MoveSpeed { set;get;}
    
    }
    public class Fighter : Player
    {
        public int FigherTypeId { set; get; }
        public Fighter(int _moveSpeed)
        {
            MoveSpeed = _moveSpeed;
        }
    }
