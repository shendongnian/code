    <ListView>
        <ListView.Items>
            <Button Content="Button 1"/>
            <Button Content="Button 2"/>
            <Button Content="Button 3"/>
            <Button Content="Button 4"/>
        </ListView.Items>
        
        <ListView.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Vertical" Background="LightCoral"/>
            </ItemsPanelTemplate>
        </ListView.ItemsPanel>
        <ListView.Template>
            <ControlTemplate>
                <Border Background="LightBlue" BorderBrush="DarkGreen" BorderThickness="5">
                    <ItemsPresenter HorizontalAlignment="Right" />
                </Border>
            </ControlTemplate>
        </ListView.Template>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="8"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="This is an item : "/>
                    <ContentPresenter Grid.Column="2" Content="{Binding}"/>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView> 
