    <TabControl ItemsSource="{Binding MyNotepadVMCollection}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBox Text="{Binding SomePropertyOnViewModel}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
