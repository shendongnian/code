    <ItemsControl ItemsSource="{Binding Path=Options}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <DataTemplate.Resources>
                            <DataTemplate DataType="{x:Type System:Boolean}">
                                <CheckBox IsChecked="{Binding Path=.}"/>
                            </DataTemplate>
                            <DataTemplate DataType="{x:Type System:String}">
                                <TextBox Text="{Binding Path=.}"/>
                            </DataTemplate>
                        </DataTemplate.Resources>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Path=Name, Mode=OneWay}"/>
                            <ContentControl Content="{Binding Path=Value}"/>
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
