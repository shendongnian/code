    [Designer(typeof(MyCustomControlDesigner1))]
    public partial class CustomControl1 : Control
    {
        public CustomControl1()
        {
            MyBox = new GroupBox();
            InitializeComponent();
            MyBox.Text = "hello world";
            Controls.Add(MyBox);
        }
        public GroupBox MyBox { get; private set; }
    }
    public class MyCustomControlDesigner1 : ParentControlDesigner
    {
        // When a control is parented, tell the parent is the GroupBox, not the control itself
        protected override Control GetParentForComponent(IComponent component)
        {
            CustomControl1 cc = (CustomControl1)Control;
            return cc.MyBox;
        }
    }
