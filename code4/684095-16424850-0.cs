    public class Connect4Board
    {
        private Box[,] _boxes = new Box[7, 6];
    
        public void DropPieceAt(int column, bool redPiece)
        {
            //Safe modifications to box colors.
        }        
    
        public IBox GetBoxAt(int x, int y)
        {
            return _boxes[x, y];
        }
    }
    
    public interface IBox
    {
        bool IsRed { get; }
        bool IsEmpty { get; }
    }
    
    internal class Box : IBox
    {
        public bool IsRed { get; private set; }
        public bool IsEmpty { get; private set; }
    }
