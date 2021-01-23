    <ControlTemplate TargetType="Button">
        <Border Name="border" BorderThickness="0" 
                    Background="Transparent">
              <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
        </Border>
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background">
                   <Setter.Value>
                       <ImageBrush ImageSource="/MyProjectName;component/Images/MyImage.jpg" />
                   </Setter.Value>
                </Setter>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
