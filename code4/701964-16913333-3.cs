            <DataGrid ItemsSource="{Binding FooBars}" AutoGenerateColumns="False" >
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Path=F.X, Mode=TwoWay}" Header="This is FOO"></DataGridTextColumn>
                    <DataGridTextColumn Binding="{Binding Path=B.Y, Mode=TwoWay}" Header="This is BAR"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
