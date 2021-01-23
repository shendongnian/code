    <DataGrid x:Name="dtgrdTheDataGrid" AutoGenerateColumns="False">
        <DataGrid.Columns>        
            <DataGridTextColumn Header="ContainingObjectId" Binding="{Binding ContainingObjectID }" />      
            <DataGridTemplateColumn Header="ContainedObject">
                <DataTemplate>
                    <TextBlock Text="Whatever you want here" />
                </DataTemplate>
            </DataGridTemplateColumn>
            <DataGridTextColumn Header="ContainedObjectId" Binding="{Binding ContainedObject.Id}" />  
            <DataGridTextColumn Header="Height" Binding="{Binding ContainedObject.Height}" />
            <DataGridTextColumn Header="Width" Binding="{Binding ContainedObject.Width}" />
        </DataGrid.Columns>
    </DataGrid>
