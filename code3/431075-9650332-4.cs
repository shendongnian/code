    <Grid>
        <Grid.DataContext>
            <Samples:DataGridValidationViewModels/>
        </Grid.DataContext>
        <DataGrid AutoGenerateColumns="False" ItemsSource={Binding Items}>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Column 1" Binding="{Binding Column1, ValidatesOnDataErrors=True}" />
                <DataGridTextColumn IsReadOnly="True" Header="Column 2" Binding="{Binding Column2, ValidatesOnDataErrors=True}" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
