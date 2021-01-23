    <Grid>
        <Grid.Resources>
            <CollectionViewSource x:Key="Animals" Source="{Binding}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="Continent" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </Grid.Resources>
        <ItemsControl ItemsSource="{Binding Source={StaticResource Animals}}">
            <ItemsControl.GroupStyle>
                <x:Static Member="GroupStyle.Default" />
            </ItemsControl.GroupStyle>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <RadioButton Content="{Binding Name}" GroupName="{Binding Continent}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
