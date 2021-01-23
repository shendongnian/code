    <Grid x:Name="ParentGrid">
        <GridView ItemsSource="{Binding Prop1}">
            <GridView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <...Source="{Binding DataContext.Prop2, ElementName=ParentGrid}"...>
                    </Grid>
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
    </Grid>
