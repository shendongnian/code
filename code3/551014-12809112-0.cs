    <ListBox ScrollViewer.VerticalScrollBarVisibility="Auto" 
           ItemsSource="{Binding Selections}" Margin="12,22,12,94">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <CheckBox IsChecked="{Binding IsChecked, Mode=TwoWay}" 
                       Content="{Binding Path=Item.SelectionName}" />
                    <TextBox Text="{Binding Item.SelectionTextField, Mode=TwoWay}" />
                </StackPanel>  
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
