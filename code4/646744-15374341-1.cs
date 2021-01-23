    <ItemsControl ItemsSource="{Binding Game.Tiles}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*"/>
                        <RowDefinition Height="*"/> 
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style>
                <Setter Property="Grid.Column" Value="{Binding Column}" />
                <Setter Property="Grid.Row" Value="{Binding Row}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate DataType="{x:Type local:Position}">
                <Ellipse Fill="{Binding FillColor}"
                         Stroke="{StaticResource TileStroke}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
