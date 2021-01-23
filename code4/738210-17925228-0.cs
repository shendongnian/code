    public static readonly DependencyProperty ItemTemplateProperty = 
       DependencyProperty.Register(
            "ItemTemplate", 
             typeof(DataTemplate), 
             typeof(MyUserControl),
             new FrameworkPropertyMetadata( ItemTemplateChanged ));
    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set
        {
            _list.ItemTemplate = value;
            SetValue(ItemTemplateProperty, value);
        }
    }
    public static void ItemTemplateChanged(
       DependencyObject sender, 
       DependencyPropertyChangedEventArgs e){
       ((MyUserControl)sender).OnItemTemplateChanged(e);
    }
    protected void OnItemTemplateChanged(DependencyPropertyChangedEventArgs e){
        // you write your code here..
    }
