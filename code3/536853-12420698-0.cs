    <ComboBox ItemsSource="{Binding AllCustomers}" SelectedValue="CustomerName">
            <ItemsControl.ItemTemplate>
                 <DataTemplate>
                     <TextBlock Text="{Binding Item.CustomerName}"/>
                 </DataTemplate>
            </ItemsControl.ItemTemplate>
    </ComboBox>
