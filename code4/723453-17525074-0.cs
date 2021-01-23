    for (int i = 0; i < lines.Count(); i++)
    {
        resultsTreeView.Items.Add(lines[i].ToString().Substring(67,17));
    }
    <TreeView x:Name="resultsTreeView" HorizontalAlignment="Left" Height="100" Margin="37,344,0,0" VerticalAlignment="Top" Width="257" >
        <TreeView.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding}"/>
                    <CheckBox/>
                </StackPanel>
            </DataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
