    public bool MyIsWorking
    {
      get { return (bool)GetValue(MyIsWorkingProperty ); }
      set { SetValue(MyIsWorkingProperty , value); }
    }
    public static readonly DependencyProperty MyIsWorkingProperty =
            DependencyProperty.Register("MyIsWorking", typeof(bool), typeof(UserControl1),    new UIPropertyMetadata(false));
