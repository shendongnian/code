    <ListView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="8"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="{Binding Path=Name}"/>
                 <!-- Displays the tags (or whatever you want) />
                <ListView Grid.Column="2" ItemsSource="{Binding Tags}"/>
            <Grid>
        </DataTemplate>
    </ListView.ItemTemplate>
