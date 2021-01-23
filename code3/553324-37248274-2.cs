    public int MyMaxRowsOrCollumns
        {
            get { return (int)GetValue(MyMaxRowsOrCollumnsProperty); }
            set { SetValue(MyMaxRowsOrCollumnsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyMaxRowsOrCollumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMaxRowsOrCollumnsProperty =
            DependencyProperty.Register("MyMaxRowsOrCollumns", typeof(int), typeof(DashBord), new PropertyMetadata(2));
