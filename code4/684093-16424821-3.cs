    public interface IBox
    {
        bool IsRed { get; }
        bool IsEmpty { get; }
    }
    public class MutableBox : IBox
    {
        public bool IsRed { get; set; }
        public bool IsEmpty {get; set; }
        public IBox MakeImmutable()
        {
            return new ImmutableBox(this);
        }
    }
    public class ImmutableBox : IBox 
    {
        private IBox innerBox;
        public ImmutableBox(IBox innerBox) { this.innerBox = innerBox; }
        public bool IsRed { get { return innerBox.IsRed; } }
        public bool IsEmpty { get { return innerBox.IsEmpty; } }
    }
    public class Connect4Board
    {
        private MutableBox[,] boxes = new MutableBox[7, 6];
        public void DropPieceAt(int column, bool redPiece)
        {
            // perform modifications
        }
       
        public IBox GetBoxAt(int x, int y)
        {
            return boxes[x,y].MakeImmutable();
        }
    }
