          <ListView ItemsSource="{Binding Path=MyItems}" x:Name="listView">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=IsSelected}" IsEnabled="{Binding Path=IsEnabled}">
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="Checked">
                                    <i:InvokeCommandAction Command="{Binding ElementName=listView, Path=DataContext.SelectCommand}"
                                                           CommandParameter="{Binding}"/>
                                </i:EventTrigger>
                                <i:EventTrigger EventName="Unchecked">
                                    <i:InvokeCommandAction Command="{Binding ElementName=listView, Path=DataContext.UnselectCommand}"
                                                           CommandParameter="{Binding}"/>
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
                        </CheckBox>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
