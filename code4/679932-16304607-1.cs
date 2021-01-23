    <ItemsControl ItemsSource="{Binding Platforms}" >
         <ItemsControl.ItemTemplate>
             <DataTemplate>
                   <Border BorderBrush="Black" BorderThickness="1">
                        <ItemsControl ItemsSource="{Binding Units}">
                              <ItemsControl.ItemTemplate>
                                   <DataTemplate>
                                        <Border BorderBrush="Green" BorderThickness="1">
                                            <ItemsControl ItemsSource="{Binding Units}">
                                              <ItemsControl.ItemsPanel>
                                                <ItemsPanelTemplate>
                                                    <StackPanel Orientation="Horizontal"></StackPanel>
                                                </ItemsPanelTemplate>
                                            </ItemsControl.ItemsPanel>
                                                <ItemsControl.ItemTemplate>
                                                    <DataTemplate>
                                                        <Border BorderBrush="Yellow" BorderThickness="1"></Border>
                                                    </DataTemplate>
                                                </ItemsControl.ItemTemplate>
                                            </ItemsControl>
                                        </Border>
                                       </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </Border>
                          </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
