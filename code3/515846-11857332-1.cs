            <ListBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding Path=Content}" IsChecked="{Binding Path=IsSelected, Mode=TwoWay}" />
                </DataTemplate>
            </ListBox.ItemTemplate>
            var data = new List<Model>()
            {
                new Model{ Content = "item1", IsSelected = false},
                new Model{ Content = "item2", IsSelected = false},
                new Model{ Content = "item1", IsSelected = false},
                new Model{ Content = "item3", IsSelected = false}
            };
            SendCodecsNamelistBox.ItemsSource = data;
