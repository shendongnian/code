    <ItemsControl>
        <ItemsControl.Resources>
            <CollectionViewSource x:Key="cvs" Source="{Binding Floors}" />
        </ItemsControl.Resources>
        <ItemsControl.ItemsSource>
            <CompositeCollection>
                <CollectionContainer Collection="{Binding Source={StaticResource cvs}" />
                <!-- Static Items -->
            </CompositeCollection>
        </ItemsControl.ItemsSource>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas ... />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>
