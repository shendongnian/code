    public class PanelExtension : StackPanel
    {
	    public bool IsReadOnly
	    {
		    get { return (bool)GetValue(IsReadOnlyProperty); }
		    set { SetValue(IsReadOnlyProperty, value); }
	    }
	    public static readonly DependencyProperty IsReadOnlyProperty =
		    DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PanelExtension),
		    new PropertyMetadata(new PropertyChangedCallback(OnIsReadOnlyChanged)));
	    private static void OnIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	    {
		    ((PanelExtension)d).OnIsReadOnlyChanged(e);
	    }
	    protected virtual void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
	    {
		    this.SetIsEnabledOfChildren();
	    }
	    public PanelExtension()
	    {
		    this.Loaded += new RoutedEventHandler(PanelExtension_Loaded);
	    }
	    void PanelExtension_Loaded(object sender, RoutedEventArgs e)
	    {
		    this.SetIsEnabledOfChildren();
	    }
	    private void SetIsEnabledOfChildren()
	    {
		    foreach (UIElement child in this.Children)
		    {
			    var readOnlyProperty = child.GetType().GetProperties().Where(prop => prop.Name.Equals("IsReadOnly")).FirstOrDefault();
			    readOnlyProperty.SetValue(child, this.IsReadOnly, null);
		    }
	    }
    }
