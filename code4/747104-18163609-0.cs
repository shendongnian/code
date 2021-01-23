    public enum ContainerLayout {
        Horizontal,
        Vertical
    }
    public class Container
    {
        public int PercentWidth { get; set; }
        public int Height { get; set; }
        public ContainerLayout Layout { get; set; }
    }
    public class ButtonBar
    {
        public Container containerTemplate = null;
        public ButtonBar(Container strategy)
        {
            containerTemplate = strategy;
        }
    }
    // Creation would be
    ButtonBar btnBar = new ButtonBar(
        new Container()
        {
            PercentWidth = 100,
            Height = 700,
            Layout = ContainerLayout.Horizontal
        }
    );
