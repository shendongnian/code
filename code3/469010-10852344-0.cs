                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <Expander Background="Gray" HorizontalAlignment="Left" IsExpanded="True"
                                                  ScrollViewer.CanContentScroll="True">
                                            <Expander.Header>
                                                <DataGrid Name="HeaderGrid" ItemsSource="{Binding Path=., Converter={StaticResource SumConverter}}"
                                                            Loaded="DataGrid_Loaded" HeadersVisibility="Row"
                                                            Margin="25 0 0 0" PreviewMouseDown="HeaderGrid_PreviewMouseDown">
                                                    <DataGrid.Style>
                                                        <Style TargetType="DataGrid">
                                                            <Style.Triggers>
                                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=Expander}, Path=IsExpanded}"
                                                                                Value="True">
                                                                    <Setter Property="Visibility" Value="Collapsed"/>
                                                                </DataTrigger>
                                                            </Style.Triggers>
                                                        </Style>
                                                    </DataGrid.Style>
                                                </DataGrid>
                                            </Expander.Header>
                                            <StackPanel>
                                                <ItemsPresenter/>
                                                <DataGrid Name="FooterGrid" ItemsSource="{Binding ElementName=HeaderGrid, Path=ItemsSource, Mode=OneWay}"
                                                                Loaded="DataGrid_Loaded" HeadersVisibility="Row"
                                                                Margin="50 0 0 0">
                                                    <DataGrid.Style>
                                                        <Style TargetType="DataGrid">
                                                            <Style.Triggers>
                                                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=Expander}, Path=IsExpanded}"
                                                                             Value="False">
                                                                    <Setter Property="Visibility" Value="Collapsed"/>
                                                                </DataTrigger>
                                                            </Style.Triggers>
                                                        </Style>
                                                </DataGrid>
                                            </StackPanel>
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
