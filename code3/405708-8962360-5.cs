    //Interface
    public interface IControl : IComponent
    {
        void DoSomething();
        Control AsWindowsForms();
    }
    //BaseUserControl
    public partial class BaseUserControl : UserControl, IControl
    {
        public BaseUserControl()
        {
            InitializeComponent();
        }
        public virtual void DoSomething()
        {
        }
        public Control AsWindowsForms()
        {
            return this as Control;
        }
    }
