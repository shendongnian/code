    <Grid Style="{StaticResource LayoutRootStyle}" x:Name="LayoutRoot">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Border x:Name="LeftPanel" Background="Red" Width="40"/>
        <mmppf:MediaPlayer x:Name="player" Grid.Column="1" IsFullScreenVisible="True" Source="http://smf.blob.core.windows.net/samples/videos/wildlife.mp4"/>
    </Grid>
    public MainPage()
    {
        this.InitializeComponent();
        player.DoubleTapped += player_DoubleTapped;
        player.IsFullScreenChanged += player_IsFullScreenChanged;
    }
    
    void player_IsFullScreenChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
    {
        LeftPanel.Visibility = e.NewValue ? Visibility.Collapsed : Visibility.Visible;
    }
    
    void player_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
        player.IsFullScreen = !player.IsFullScreen;
    }
