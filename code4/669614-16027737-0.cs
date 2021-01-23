     <ListView ItemsSource="{Binding}" Grid.Column="1">
                <ListView.Resources>
                    <DataTemplate x:Key="CellContentTemplate">
                        <Border BorderBrush="LightGray" BorderThickness="1">
                            <DockPanel>
                                <Image Height="20" Width="20" Source="{Binding ImageSource}" Margin="2"
                                   DockPanel.Dock="Left"/>
                                <StackPanel>
                                    <TextBlock Text="{Binding Value, StringFormat='${0}'}" Margin="2"/>
                                    <TextBlock Text="{Binding Name}" Margin="2"/>
                                </StackPanel>
                            </DockPanel>
                        </Border>
                        
                    </DataTemplate>
                </ListView.Resources>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header=""  DisplayMemberBinding="{Binding Name}"/>
                        <GridViewColumn Header="Pitts">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ContentPresenter Content="{Binding Pitts}" ContentTemplate="{StaticResource CellContentTemplate}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Vans">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ContentPresenter Content="{Binding Vans}" ContentTemplate="{StaticResource CellContentTemplate}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Lancair">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ContentPresenter Content="{Binding Lancair}" ContentTemplate="{StaticResource CellContentTemplate}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Epic">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ContentPresenter Content="{Binding Epic}" ContentTemplate="{StaticResource CellContentTemplate}"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
