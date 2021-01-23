    <ListView Name="ListViewSongs">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch"></Setter>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
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
