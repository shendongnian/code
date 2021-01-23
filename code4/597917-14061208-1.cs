    public class MyCustomButton : UserControl
    {
        public MyCustomButton()
        {
        }
        public Brush MyVarColor1
        {
            get { return (Brush)GetValue(MyVarColor1Property); }
            set { SetValue(MyVarColor1Property, value); }
        }
        // Using a DependencyProperty as the backing store for MyVarColor1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyVarColor1Property =
            DependencyProperty.Register("MyVarColor1", typeof(Brush), typeof(MyCustomButton), new UIPropertyMetadata(null));
        public double MyVarIconX
        {
            get { return (double)GetValue(MyVarIconXProperty); }
            set { SetValue(MyVarIconXProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyVarIconX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyVarIconXProperty =
            DependencyProperty.Register("MyVarIconX", typeof(double), typeof(MyCustomButton), new UIPropertyMetadata(0));
        public Uri MyVarIconUrl
        {
            get { return (Uri)GetValue(MyVarIconUrlProperty); }
            set { SetValue(MyVarIconUrlProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyVarIconUrl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyVarIconUrlProperty =
            DependencyProperty.Register("MyVarIconUrl", typeof(Uri), typeof(MyCustomButton), new UIPropertyMetadata(null));
    }
