    <ListView ItemsSource="{Binding SelectedTechnician.Tests}"
    SelectedItem="{Binding SelectedTest}" x:Name="AvailableTestsListView" Height="140">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Id" Width="auto" DisplayMemberBinding="{Binding Id}"/>
                <GridViewColumn Header="Test" Width="auto" DisplayMemberBinding="{Binding TestTypeName}"/>
                <GridViewColumn Header="Status" Width="auto">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock
                                Text="{Binding StatusTypeName}"
                                Foreground="{Binding StatusTypeName, Converter={StaticResource StatusTypeNameToBrushConverter}}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
            </GridView>
        </ListView.View>
    </ListView>
