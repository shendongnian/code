    <DataGrid ItemsSource={Binding Source={StaticResource PersonsData}} AutoGenerateColumns="false">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Person Id" Content={Binding PersonId} />
            <DataGridTextColumn Header="First Name" Content={Binding FirstName} />
            <DataGridTextColumn Header="Last Name" Content={Binding LastName} />
        </DataGrid.Columns>
    </DataGrid>
    
    <DataGrid ItemsSource={Binding Source={StaticResource PersonsData}} AutoGenerateColumns="false">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Person Id" Content={Binding PersonId} />
            <DataGridTextColumn Header="Address" Content={Binding Address} />
            <DataGridTextColumn Header="Position" Content={Binding Position} />
        </DataGrid.Columns>
    </DataGrid>
