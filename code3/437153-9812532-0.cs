    <Page.DataContext>
        <Samples:TreeViewDblClickViewModel/>
    </Page.DataContext>
    <Grid>
        <TreeView ItemsSource="{Binding Items}">
            <TreeView.ItemTemplate>
                <DataTemplate>
                    <ContentControl>
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="MouseDoubleClick">
                                <i:InvokeCommandAction Command="{Binding DoubleClickCommand}"/>
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                        <TextBlock Text="{Binding Name}" Background="AliceBlue" Margin="2"/>
                    </ContentControl>
                </DataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
    </Grid>
