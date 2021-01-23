    <ItemsControl ItemsSource="{Binding Source={StaticResource TrucksSource}}">
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Loaded">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard Storyboard.TargetProperty="Opacity">
                                    <DoubleAnimation From="0.0"
                                                     To="1.0"
                                                     Duration="00:00:01"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding TruckId}" Background="Aqua"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
