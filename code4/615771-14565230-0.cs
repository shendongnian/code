    public static readonly DependencyProperty CurrentValueProperty =
           DependencyProperty.Register("CurrentValue", typeof(DataValue), typeof(UserControl1),
           new PropertyMetadata(new PropertyChangedCallback(OnCurrenValueChanged)));
    private static void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 uc = d as UserControl1;
            if (e.NewValue != null)
            {
                uc.dm.CurrentValue = e.NewValue as DataValue;
            }
        }
    public DataValue CurrentValue
    {
            get { return GetValue(CurrentValueProperty) as DataValue; }
            set { SetValue(CurrentValueProperty, value); }
        }
