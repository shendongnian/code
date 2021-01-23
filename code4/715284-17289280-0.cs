    <sdk:DataGrid Name="dataGrid" AutoGenerateColumns="False" SelectionMode="Single">
            <sdk:DataGrid.Columns>
                <sdk:DataGridTextColumn 
                    Header="Book Name" 
                    Binding="{Binding Name, Mode=TwoWay}"/>
                <sdk:DataGridTextColumn 
                    Header="Book Type" 
                    Binding="{Binding BookType, Mode=TwoWay}"/>
            </sdk:DataGrid.Columns>
        </sdk:DataGrid>
