    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    //Interface
    public interface IControl : IComponent
    {
        void DoSomething();
    }
    //Factory
    public class ControlFactory
    {
        public static IControl Create(string name)
        {
            switch (name)
            {
                case "UserControlA":
                    var userControlA = new UserControlA();
                    return userControlA;
                case "UserControlB":
                    var userControlB = new UserControlB();
                    return userControlB;
            }
            return null;
        }
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
    }
    public partial class UserControlA : BaseUserControl, IControl
    {
        public UserControlA()
        {
            InitializeComponent();
        }
        public override void DoSomething()
        {
            //Do something here
        }
    }
    public partial class UserControlB : BaseUserControl, IControl
    {
        public UserControlB()
        {
            InitializeComponent();
        }
        public override void DoSomething()
        {
            //Do something here
        }
    }
