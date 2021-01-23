    public class YellowPainter : IVisitor<House>
    {
        public void Visit(House visitable)
        {
            visitable.Color = Color.Yellow;
        }
    }
