    <ListView Name="ResultsView" 
                  HorizontalContentAlignment="Stretch">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid Background="Yellow">
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
