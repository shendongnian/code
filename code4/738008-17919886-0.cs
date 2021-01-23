    public static readonly DependencyProperty ButtonColorProperty = 
        DependencyProperty.Register("ButtonColor", typeof(Color), typeof(MyUserControl),
        new PropertyMetadata(Colors.Blue));
    public Color State
    {
        get { return (Color)this.GetValue(ButtonColorProperty); }
        set { this.SetValue(ButtonColorProperty, value); } 
    }
    <UserControl ...
                 x:Name="root">
        <Button Content="Button" Background="{Binding ElementName=root, Path=ButtonColor}" />
    </UserControl>
