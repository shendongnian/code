       <ItemsControl Name="userControl">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding aObjectsList}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name}" />
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
