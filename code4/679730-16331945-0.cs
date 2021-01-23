    using System;
    using System.Windows;
    using System.Windows.Input;
    namespace Gui.CustomControls
    {
    public partial class MenuItem : DevExpress.AgMenu.AgMenuItem
    {
        public MenuItem()
        {
            InitializeComponent();
        } 
        
    #region CommandParameter DependencyProperty
        public static Object GetCommandParameter(DependencyObject obj)
        {
            return (Object)obj.GetValue(CommandParameterProperty);
        }
        public static void SetCommandParameter(DependencyObject obj, Object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }
        public static readonly DependencyProperty CommandParameterProperty =  DependencyProperty.RegisterAttached("CommandParameter", typeof(Object), typeof(Gui.CustomControls.MenuItem), new PropertyMetadata(OnCommandParameterChanged) );
        private static void OnCommandParameterChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            DependencyObject _DependencyObject = (DependencyObject)sender;
            if ((args.NewValue != null) && (_DependencyObject != null))
            {
                MenuItem.SetCommandParameter(_DependencyObject, args.NewValue);
            }
        } 
        
    #endregion
    #region Command
        private static void OnCommandChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            DependencyObject _DependencyObject = (DependencyObject)sender;
            ICommand         _ICommand         = (ICommand)args.NewValue;
            
            if ((_ICommand != null) && (_DependencyObject != null))
            {
                SetCommand(_DependencyObject, _ICommand);
            }
        }
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(Gui.CustomControls.MenuItem), new PropertyMetadata(OnCommandChanged));
    #endregion
    #region LeftMouseButtonUp (Command Trigger)
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            ICommand _ICommand = MenuItem.GetCommand(this);
            Object _CommandParameter = MenuItem.GetCommandParameter(this);
            if (_ICommand != null)
            {
                _ICommand.Execute(_CommandParameter);
            }
        } 
        
    #endregion
    }
}
