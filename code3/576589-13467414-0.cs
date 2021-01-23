        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="First Name" Binding="{Binding FirstName, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="Last Name" Binding="{Binding LastName, UpdateSourceTrigger=PropertyChanged}"/>
            </DataGrid.Columns>
        </DataGrid>
