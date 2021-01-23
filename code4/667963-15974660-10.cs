    <DataGrid AutoGenerateColumns="False"
              ItemsSource="{Binding Data}"
              RowDetailsVisibilityMode="Visible">
      <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding P1}" />
        <DataGridTextColumn Binding="{Binding P2}" />
      </DataGrid.Columns>
      <DataGrid.RowDetailsTemplate>
        <DataTemplate>
          <DataGrid AutoGenerateColumns="False"
                    ItemsSource="{Binding DictionaryInA.Values}"
                    RowDetailsVisibilityMode="Visible">
            <DataGrid.RowDetailsTemplate>
              <DataTemplate>
                <DataGrid AutoGenerateColumns="False"
                          ItemsSource="{Binding DictionaryInB.Values}">
                  <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding P1}" />
                    <DataGridTextColumn Binding="{Binding P2}" />
                  </DataGrid.Columns>
                </DataGrid>
              </DataTemplate>
            </DataGrid.RowDetailsTemplate>
            <DataGrid.Columns>
              <DataGridTextColumn Binding="{Binding P1}" />
              <DataGridTextColumn Binding="{Binding P2}" />
            </DataGrid.Columns>
          </DataGrid>
        </DataTemplate>
      </DataGrid.RowDetailsTemplate>
    </DataGrid>
