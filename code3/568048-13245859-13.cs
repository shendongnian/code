    public class Behavior<T> where T : class 
    {
        public T AssociatedObject
        {
            get;
            private set;
        }
        public Behavior(T associatedObject)
        {
            this.AssociatedObject = associatedObject;
        }
        public virtual void Attach() { }
        public virtual void Detach() { }
    }
    public class DragBehavior : Behavior<Control>
    {
        Point dragPoint = Point.Empty;
        bool dragging = false;
        bool mouseDown = false;
        public DragBehavior(Control c) : base(c)
        {
        }
        public override void Attach()
        {
            AssociatedObject.MouseDown += new MouseEventHandler(control_MouseDown);
            AssociatedObject.MouseMove += new MouseEventHandler(control_MouseMove);
            AssociatedObject.MouseUp += new MouseEventHandler(control_MouseUp);
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            mouseDown = false;
        }
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = e.X - dragPoint.X;
            int deltaY = e.Y - dragPoint.Y;
            if (mouseDown && deltaX * deltaX + deltaY * deltaY > 100)
                dragging = true;
            if (dragging)
                AssociatedObject.Location = new Point(AssociatedObject.Location.X + deltaX, AssociatedObject.Location.Y + deltaY);
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            dragPoint = new Point(e.X, e.Y);
        }
        public override void Detach()
        {
            AssociatedObject.MouseDown -= new MouseEventHandler(control_MouseDown);
            AssociatedObject.MouseMove -= new MouseEventHandler(control_MouseMove);
            AssociatedObject.MouseUp -= new MouseEventHandler(control_MouseUp);
        }
    }
    public partial class Form1 : Form
    {
        DragBehavior dragger;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            dragger = new DragBehavior(pic);
            dragger.Attach();
        }       
    }
