    <DataGridTextColumn Header="ColA" Binding="{Binding colA, StringFormat=\{0:P\}}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Setter Property="Background" 
                        Value="{Binding colA, Converter={StaticResource valueToForeground}}" />
             </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
    <DataGridTextColumn Header="ColB" Binding="{Binding colB, StringFormat=\{0:P\}}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Setter Property="Background" 
                        Value="{Binding colB, Converter={StaticResource valueToForeground}}" />
             </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
    ...
