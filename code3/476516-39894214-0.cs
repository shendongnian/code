    Try this one...
    <Style x:Key="PressedButtonEffect" TargetType="Button">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Name="border" Background="Transparent" BorderThickness="1" BorderBrush="Gray">
                            <ContentPresenter/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="Button.IsPressed" Value="True">
                                <Setter TargetName="border" Property="BorderBrush" Value="DarkGray" />
                                <Setter TargetName="border" Property="BorderThickness" Value="2" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
