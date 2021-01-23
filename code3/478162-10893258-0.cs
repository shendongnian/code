    public interface IGraphic
    {
        void Draw();
    }
    public class SVG
    {
        public GraphicGroup GraphicGroup { get; set; }
    }
    public class GraphicGroup : IGraphic
    {
        public GraphicGroup(Collection<IGraphic> graphics)
        {
            this.Graphics = graphics;
        }
        public Collection<IGraphic> Graphics { get; private set; }
        public void Draw()
        {
            Console.WriteLine("Drawing Graphic Group");
            foreach (IGraphic graphic in this.Graphics)
            {
                graphic.Draw();
            }
        }
    }
    public class Circle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }
