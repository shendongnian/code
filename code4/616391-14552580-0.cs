    <ControlTemplate TargetType="Button">
        <Border Name="border" BorderThickness="0" Background="{TemplateBinding Background}">
            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" Width="15" Height="15" />
        </Border>
        <ControlTemplate.Triggers>
            <DataTrigger Binding="{Binding MyCondition}" Value="False">
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="exclude.png" />
                    </Setter.Value>
                </Setter>
            </DataTrigger >
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="exclude_hover.png" />
                    </Setter.Value>
                </Setter>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
