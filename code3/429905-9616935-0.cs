    <DataTemplate DataType="{x:Type vm:Seat}">
        <Border CornerRadius="3" Width="{Binding Metrics.Size.Width}" Height="{Binding Metrics.Size.Height}" BorderThickness="2" MouseEnter="MouseEnter" MouseLeave="MouseLeave">
            <Border.RenderTransform>
                <ScaleTransform x:Name="ZoomTransform" ScaleX="1" ScaleY="1"/>
            </Border.RenderTransform>
            <Border.InputBindings>
                <MouseBinding Gesture="LeftClick" Command="{Binding LeftClickCommand}"/>
                <MouseBinding Gesture="RightClick" Command="{Binding RightClickCommand}"/>
            </Border.InputBindings>
            <Border.Style>
                <Style TargetType="{x:Type Border}">
                    <Setter Property="BorderBrush" Value="{Binding PriceBorderColour}"></Setter>
                    <Setter Property="Background" Value="{Binding Template.StandardBrush}"></Setter>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsSelected}" Value="True">
                            <Setter Property="Background" Value="{Binding SelectedTemplate.StandardBrush}"/>
                        </DataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Mode=Self}, Path=IsMouseOver}" Value="True"/>
                                <Condition Binding="{Binding Plan.EditModel.EditEnabled}" Value="True"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Cursor" Value="Pen"/>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Border.Style>
            <Viewbox>
                <TextBlock Text="{Binding ObjectLabel.Text}" Foreground="{Binding ObjectLabel.FontColour}"/>
            </Viewbox>
        </Border>
    </DataTemplate>
