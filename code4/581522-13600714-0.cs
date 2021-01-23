    <ItemsControl ItemsSource="{Binding ListOfBanks}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
            <StackPanel>
                <TextBlock Text="{Binding ListOfAccounts.Count,StringFormat='Number of Accounts: {0}'}" />
                <ItemsControl ItemsSource="{Binding ListOfAccounts}">
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding Description}" />
                            <TextBlock Grid.Column="1" Text="{Binding Money,StringFormat='{}{0:C}'}" />
                        </Grid>
                    </DataTemplate>
                </ItemsControl>
            </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
