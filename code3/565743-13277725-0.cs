    <Style x:Key="MusicOffButtonStyle" TargetType="Button" BasedOn="{StaticResource AppBarButtonStyle}">
    <Setter Property="AutomationProperties.AutomationId" Value="MusicOffButton"/>
    <Setter Property="AutomationProperties.Name" Value="Music OFF"/>
    <Setter Property="Content" Value=""/>
    </Style>
    <Style x:Key="MusicOnButtonStyle" TargetType="Button" BasedOn="{StaticResource AppBarButtonStyle}">
    <Setter Property="AutomationProperties.AutomationId" Value="MusicOnButton"/>
    <Setter Property="AutomationProperties.Name" Value="Music ON"/>
    <Setter Property="Content" Value=""/>
    </Style>
    
    private void SetMusicButtonIcon()
    {
    MusicButton.Style = (ifMuted) ? (this.Resources["MusicOffButtonStyle"] as Style) : (this.Resources["MusicOnButtonStyle"] as Style);
    
    }
