    public class ScrollableWidget : Control, INamingContainer, ISCrollable, IWidget
    {
        private Scroller ScrollBehaviour;
        private Widgeter = WidgetBehaviour;
        public Control Target { get; private set; }
        public ScrollBar Bar { get; private set; }
        public double FullLength { get; private set; }
        public double VisibleLength { get; private set; }
        public ScrollableWidget()
        {
            this.Target = this;
            this.Bar = CreateScrollBarControl();
            this.FullLength = 9001;
            this.VisibleLength = this.ActualHeight;
            this.ScrollBehaviour = new Scroller(this);
            this.WidgetBehaviour = new Widgeter(this);
        }
    }
