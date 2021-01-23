    <Page.Resources>
        <Style x:Key="CustomButtonStyle" TargetType="Button">
            <Setter Property="Background" Value="Orange"/>
            <Setter Property="Foreground" Value="Black"/>
            <Setter Property="FontFamily" Value="Comic Sans MS"/>
            <Setter Property="FontSize" Value="30"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Grid>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal"/>
                                    <VisualState x:Name="PointerOver">
                                        <Storyboard>
                                            <ColorAnimation Duration="0" To="LightGray" Storyboard.TargetProperty="(Rectangle.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="Border" />
                    </Storyboard>
                  </VisualState>
                  <VisualState x:Name="Pressed">
                    <Storyboard>
                      <ColorAnimation Duration="0" To="Black" Storyboard.TargetProperty="(Rectangle.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="Border" />
                      <ColorAnimation Duration="0" To="White" Storyboard.TargetProperty="(TextBlock.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="Content" />
                    </Storyboard>
                  </VisualState>
               </VisualStateGroup>
              </VisualStateManager.VisualStateGroups>
              <Grid>
                <Rectangle x:Name="Border" Stroke="Black" Fill="Orange" Margin="-5"/>
                <ContentPresenter x:Name="Content"/>
              </Grid>
            </Grid>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
    </Page.Resources>
