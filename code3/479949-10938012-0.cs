    <StackPanel>
        <ItemsControl x:Name="itemsControl" Height="300">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel IsItemsHost="True" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Rectangle Width="80" Height="80" Fill="Red" Margin="4" Opacity="0">
                        <Rectangle.RenderTransform>
                            <TranslateTransform Y="20" />
                        </Rectangle.RenderTransform>
                        <Rectangle.Triggers>
                            <EventTrigger RoutedEvent="Loaded">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetProperty="Opacity" To="1" Duration="00:00:00.6" />
                                        <DoubleAnimation Storyboard.TargetProperty="(RenderTransform).Y" To="0" Duration="00:00:00.4" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                        </Rectangle.Triggers>
                    </Rectangle>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
        <Button Width="60" Height="40" Content="Add Item" Click="Button_Click" />
    </StackPanel>
