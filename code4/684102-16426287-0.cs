    [Flags]
    public enum BoxState
    {
        Empty = 0,
        Red = 1 << 0,
        Black = 1 << 1
    }
    
    [Flags]
    public enum BoardColor
    {
        Red = 1 << 0,
        Black = 1 << 1
    }
    
    public interface IBox
    {
        BoxState State { get; }
    }
    
    public class Box : IBox
    {
        public BoxState State { get; set; }
    }
    
    public class ReadOnlyBox : IBox
    {
        private readonly IBox _box;
    
        public ReadOnlyBox(IBox box)
        {
            _box = box;
        }
        
        public BoxState State { get { return _box.State; } }
    }
    
    public class Connect4Board
    {
        private const int _boardWidth = 7;
        private const int _boardHeight = 6;
        private Box[,] _boxes = new Box[_boardWidth, _boardHeight];
    
        public void DropPieceAt(int column, BoardColor color)
        {
            for(int height = 0; height < _boardHeight; height++)
            {
                if(_boxes[column, height].State != BoxState.Empty) continue;
                
                _boxes[column, height].State = (BoxState)color;
                break;
            }
        }        
    
        public IBox GetBoxAt(int x, int y)
        {
            return new ReadOnlyBox(_boxes[x, y]);
        }
    }
