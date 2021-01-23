    <ItemsControl ItemsSource="{Binding Categories, Mode=TwoWay}">
         <ItemsControl.ItemTemplate>
              <DataTemplate>
                    <CheckBox IsChecked="{Binding Value.IsFavorite, Mode=TwoWay}"
                              Content="{Binding Key}" />
              </DataTemplate>
         </ItemsControl.ItemTemplate>
    </ItemsControl>
