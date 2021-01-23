    <ItemsControl ItemsSource="{Binding Path=Values}" Margin="10">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ComboBox SelectedValue="{Binding Path=Value}" Margin="5">
                    <ComboBox.ItemsSource>
                        <Int32Collection >1,2,3,4,5</Int32Collection>
                    </ComboBox.ItemsSource>
                </ComboBox>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
