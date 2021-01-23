    <UserControl.DataContext>
        <local:NodeViewModel  />
    </UserControl.DataContext>
    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="notSelectedItemTemplate" DataType="{x:Type local:NodeViewModel}" >
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="20*" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="100*" />
                        <ColumnDefinition Width="100*" />
                        <ColumnDefinition Width="100*" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Id}"></TextBlock>
                    <TextBlock Grid.Column="1" Text="----"></TextBlock>
                    <TextBlock Grid.Column="2" Text="{Binding Name}"></TextBlock>
                </Grid>
            </DataTemplate>
            <DataTemplate x:Key="selectedItemTemplate" DataType="{x:Type local:NodeViewModel}">
                <Grid Height="Auto" Background="SkyBlue" TextElement.Foreground="Black">
                    <Grid.RowDefinitions>
                        <!--<RowDefinition Height="Auto"></RowDefinition>-->
                        <RowDefinition Height="Auto"></RowDefinition>
                        <RowDefinition Height="Auto"></RowDefinition>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="20"></ColumnDefinition>
                        <ColumnDefinition Width="Auto"></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <!--<TextBlock Grid.Row="0" Grid.Column="1" Text="{Binding Id}"></TextBlock>-->
                    <TextBlock Grid.Row="0" Grid.Column="1" Text="{Binding Name}"></TextBlock>
                    <TextBlock Grid.Row="1" Grid.Column="1" Text="{Binding Description}"></TextBlock>
                </Grid>
            </DataTemplate>
        </Grid.Resources>
        <TreeView Height="Auto" HorizontalAlignment="Stretch" Margin="10" VerticalAlignment="Stretch" Width="Auto" ItemsSource="{Binding Children}">
            <TreeView.Resources>
                <!-- remove normal selected item background -->
                <SolidColorBrush Color="Transparent" x:Key="{x:Static SystemColors.HighlightBrushKey}"/>
            </TreeView.Resources>
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                </Style>
            </TreeView.ItemContainerStyle>
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate DataType="{x:Type local:NodeViewModel}" ItemsSource="{Binding Children}">
                    <ContentPresenter x:Name="item" ContentTemplate="{StaticResource notSelectedItemTemplate}" />
                    <HierarchicalDataTemplate.Triggers>
                        <DataTrigger Binding="{Binding IsSelected}" Value="True">
                            <Setter TargetName="item" Property="ContentTemplate" Value="{StaticResource selectedItemTemplate}" />
                        </DataTrigger>
                    </HierarchicalDataTemplate.Triggers>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
    </Grid>
