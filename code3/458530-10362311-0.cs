    <DataGrid ItemsSource="{Binding GroupedCustomers}">
    <DataGrid.GroupStyle>
        <GroupStyle>
            <GroupStyle.HeaderTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Path=Name}" />
                    </StackPanel>
                </DataTemplate>
            </GroupStyle.HeaderTemplate>
            <GroupStyle.ContainerStyle>
                <Style TargetType="{x:Type GroupItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type GroupItem}">
                                <Expander>
                                    <Expander.Header>
                                        <StackPanel Orientation="Horizontal">
                                          <TextBlock Text="{Binding Path=Name}" />
                                          <TextBlock Text="{Binding Path=ItemCount}"/>
                                          <TextBlock Text="Items"/>
                                        </StackPanel>
                                    </Expander.Header>
                                    <ScrollViewer Height="100">
                                         <ItemsPresenter/>
                                    </ScrollViewer>
                                </Expander>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </GroupStyle.ContainerStyle>
        </GroupStyle>
    </DataGrid.GroupStyle>
