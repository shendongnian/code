    public String MeetingX
    {
      get { return (String)this.GetValue(MeetingXProperty); }
      set { this.SetValue(MeetingXProperty, value); } 
    }
    public static readonly DependencyProperty MeetingXProperty = DependencyProperty.Register(
        "MeetingX", typeof(String), typeof(MeetingOverview),new PropertyMetadata(""));
