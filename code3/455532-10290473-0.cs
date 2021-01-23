    <Window.Resources>
        <Style x:Key="NotSelectableColumStyle" TargetType="{x:Type DataGridCell}">
            <Setter Property="IsEnabled" Value="False"/>
        </Style>
    </Window.Resources>
    <Grid Name="LayoutRoot">
         <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn   Binding="{Binding Path=Age}" />
                <!--<Disable this column>-->    
                <DataGridTextColumn   CellStyle="{StaticResource NotSelectableColumStyle}" Binding="{Binding Path=Name}" />
                <DataGridTextColumn  Binding="{Binding Path=Address}" />
            </DataGrid.Columns>
        </DataGrid>
     </Grid>
