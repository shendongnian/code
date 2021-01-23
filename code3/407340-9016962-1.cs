    public partial class ElementControl : UserControl
    {
        #region DependencyProperty ElementNameProperty
        public static DependencyProperty ElementNameProperty = DependencyProperty.Register("ElementName",
            typeof(string),
            typeof(ElementControl),
            new PropertyMetadata(new PropertyChangedCallback((s, e) => 
        { 
        //See Here
        ((ElementControl)s).UCText.Text = e.NewValue as string; 
        })));
        public string ElementName
        {
            get
            {
                return (string)base.GetValue(ElementNameProperty);
            }
            set
            {
                base.SetValue(ElementNameProperty, value);
            }
        }
        #endregion
    }
