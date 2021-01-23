     <DataGrid Grid.Column="2" Name="DG1" ItemsSource="{Binding}" SelectedItem="{Binding SelectedItem}"  AutoGenerateColumns="False" >
         <DataGrid.Columns>
             <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Command="{Binding Path=DataContext.DeleteMyCustomObjectCommand,RelativeSource={RelativeSource FindAncestor,AncestorType={x:Type DataGrid}}}" 
                                CommandParameter="{Binding RelativeSource=
                                                  {RelativeSource FindAncestor,
                                                  AncestorType={x:Type DataGrid}}}"  Width="20">
                             <Image Source="/MyThing;component/Images/delete.png" Height="16" Width="16"/>
                       </Button>
                    </DataTemplate>
               </DataGridTemplateColumn.CellTemplate>
           <DataGridTemplateColumn>
        <DataGrid.Columns>
    </DataGrid>
