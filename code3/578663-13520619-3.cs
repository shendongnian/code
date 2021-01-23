    <DataGrid Name="dgStudents" 
                      AutoGenerateColumns="False">
                <DataGrid.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="ClassA" Click="ClassA_Click" />
                        <MenuItem Header="ClassB" Click="ClassB_Click" />
                    </ContextMenu>
                </DataGrid.ContextMenu>
                
                <DataGrid.Columns>
                    <DataGridTextColumn Header="ID" Binding="{Binding ID}" />
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                    <DataGridTextColumn Header="Surname" Binding="{Binding Surname}" />
                    <DataGridTextColumn Header="Class" Binding="{Binding ClassName}" />
                </DataGrid.Columns>
            </DataGrid>
