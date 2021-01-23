    <ItemsControl ItemsSource="{Binding Lines}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Path Stroke="Black" StrokeThickness="1">
                    <Path.Data>
                        <LineGeometry StartPoint="{Binding P1}" EndPoint="{Binding P2}">
                            <LineGeometry.Transform>
                                <ScaleTransform
                                    ScaleX="{Binding Value, ElementName=slider}"
                                    ScaleY="{Binding Value, ElementName=slider}"/>
                            </LineGeometry.Transform>                                
                        </LineGeometry>
                    </Path.Data>
                </Path>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
    ...
    <Slider Width="200" Minimum="1" Maximum="10" x:Name="slider"/>
