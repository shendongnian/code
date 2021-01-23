    <UserControl.Resources>
        <DataGrid ItemsSource={binding} x:Key="DataGrid1">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{ID}"/>
                <DataGridTextColumn Binding="{Name}"/>
            </DataGrid.Columns>
        </DataGrid>
        <DataGrid ItemsSource={binding} x:Key="DataGrid2">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{ID}"/>
                <DataGridCheckBoxColumn Binding="{Accepted}"/>
            </DataGrid.Columns>
        </DataGrid>
    </UserControl.Resources>
    <Grid>
        <ContentControl Content="{StaticResource DataGrid1}" DataContext="{Binding MyTable}" Name="myContent"/}    
    </Grid>
