        <TabControl ItemsSource="{Binding Items}"
            SelectedItem="{Binding MySelectedItem, Mode=TwoWay}">
    <TabControl.ItemTemplate>
        <DataTemplate>
            <... here goes the UI to display ItemType ... >
        </DataTemplate>
      </TabControl.ItemTemplate>
    </TabControl>
