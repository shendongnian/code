    <ListView Name="ListViewSongs">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid Width="500" VerticalAlignment="Center">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="120" />
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="150" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Artist}" />
                    <TextBlock Grid.Column="1" Text="{Binding ArtistName}" />
                    <TextBlock Grid.Column="2" Text="{Binding SongName}" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
