     <Grid>
        <ListView Name="ResultsView">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="1*" />
                            <ColumnDefinition Width="4*" />
                            <ColumnDefinition Width="4*" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="{Binding BestRank}" Grid.Column="0"/>
                        <TextBlock Text="{Binding PlayerName}" Grid.Column="1"/>
                        <TextBlock Text="{Binding BestScore}" Grid.Column="2"/>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
