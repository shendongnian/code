    <ContextMenu x:Key="mnuContextTreeView" 
                 DataContext="{Binding RelativeSource={RelativeSource Self},
                                       Path=PlacementTarget.DataContext}">
        <ContextMenu.ItemsSource>
            <CompositeCollection>
                <CollectionContainer Collection="{StaticResource mnuRun}" />
                <Separator />
                <CollectionContainer Collection="{StaticResource mnuResults}" />
                <Separator />
                <MenuItem Header="{Binding Path=Flagged,
                                           Mode=OneWay, 
                                           Converter={StaticResource flaggedToHeaderConverter}}"   
                          Command="local:MainWindow.MarkFlagged" />
                <CollectionContainer Collection="{StaticResource mnuStandardEdit}" />
            </CompositeCollection>
        </ContextMenu.ItemsSource>
    </ContextMenu>
