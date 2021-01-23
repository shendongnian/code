    public static void MyDPPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = ((MyUserControl)obj);
            control.MyDP = (string)e.NewValue;
            control._textBlock.Text = control.MyDP;
        }
