        <ListView ItemsSource="{Binding Model.TablesView}"   Grid.Row="1" 
                  SelectedItem="{Binding Model.SelectedTable, Mode=TwoWay}"  >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Path=.}" >
                        <TextBlock.InputBindings>
                            <MouseBinding MouseAction="LeftDoubleClick" Command="{Binding DataContext.MoveItemRightCommand,
                                            RelativeSource={RelativeSource FindAncestor, 
                                            AncestorType={x:Type UserControl}}}"
                                          CommandParameter="{Binding .}"/>
                        </TextBlock.InputBindings>
                    </TextBlock>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
