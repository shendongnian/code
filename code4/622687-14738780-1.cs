    <ItemsControl ItemsSource="{Binding DrawingInstructions}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate >
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Line Name="CurrentLine" X1="{Binding X1}" Y1="{Binding Y1}" Stroke="Black" StrokeThickness="2">
                    <Line.Triggers>
                        <EventTrigger RoutedEvent="Loaded">
                            <BeginStoryboard>
                                <Storyboard >
                                    <DoubleAnimation Duration="0:0:2" Storyboard.TargetName="CurrentLine" Storyboard.TargetProperty="X2" From="{Binding Path=X1}" To="{Binding Path=X2}"/>
                                    <DoubleAnimation Duration="0:0:2" Storyboard.TargetName="CurrentLine" Storyboard.TargetProperty="Y2" From="{Binding Path=Y1}" To="{Binding Path=Y2}"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Line.Triggers>
                </Line>
            </DataTemplate>
        </ItemsControl.ItemTemplate>            
    </ItemsControl>
