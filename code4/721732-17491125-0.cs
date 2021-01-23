    <wpfApplication12:DataGridColumnDynamicStyleService TargetGrid="{Binding ElementName=Grid}">
            <wpfApplication12:DataGridColumnDynamicStyleService.ColumnStyles>
                <wpfApplication12:DataGridColumnStyleBinding ColumnTag="C1" DynamicStyle="{DynamicResource BaseCellClass}" />
            </wpfApplication12:DataGridColumnDynamicStyleService.ColumnStyles>
        </wpfApplication12:DataGridColumnDynamicStyleService>
        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding ElementName=WholeWindow, Path=ViewModel.Objects}" x:Name="Grid">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding F1}" Header="F1" wpfApplication12:DataGridColumnDynamicStyle.ColumnTag="C1" />
                <DataGridTextColumn Binding="{Binding F2}" Header="F2" wpfApplication12:DataGridColumnDynamicStyle.ColumnTag="C2" />
            </DataGrid.Columns>
        </DataGrid>
