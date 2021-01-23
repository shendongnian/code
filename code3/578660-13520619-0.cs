    <DataGrid Name="dgStudents" 
                      AutoGenerateColumns="False"
                      SelectionChanged="dgStudents_SelectionChanged">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="ID" Binding="{Binding ID}" />
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                    <DataGridTextColumn Header="Surname" Binding="{Binding Surname}" />
                </DataGrid.Columns>
            </DataGrid>
