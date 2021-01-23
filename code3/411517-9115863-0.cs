    // ... UserControl code-behind ...
    private bool mCanClick = false;
    public bool CanClick
    {
        get { return mCanClick; }
    }
    
    // ... UserControl XAML ...
    <UserControl ... DataContext="{Binding RelativeSource={RelativeSource Self}}">
    
    ...
    
        <Button CanClick="{Binding CanClick}" Click="Button_Click" />
    
    ...
    
    </UserControl>
