    <ListBox ItemsSource="{Binding Allotments}" Grid.Row="1">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                </Grid>
                <TextBox Text="{Binding AllotmentCode}"/>
                <TextBox Text="{Binding AllotmentName}" Grid.Column="2"/>
            </DataTemplate
        </ListBox.ItemTemplate>
    </ListBox>
