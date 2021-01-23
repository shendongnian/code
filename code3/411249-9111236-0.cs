    <DataGrid Margin="0,0,195,72" x:Name="A"> 
                <DataGrid.Resources>
                    <ContextMenu x:Key="ContextMenu">
                        <MenuItem Header="Copy" Click="MenuItem_Click"></MenuItem>
                        <MenuItem Header="cut" Click="MenuItem_Click"></MenuItem>
                        <MenuItem Header="delete" Click="MenuItem_Click"></MenuItem>
                    </ContextMenu>
                </DataGrid.Resources>
    
                <DataGrid.CellStyle>
                    <Style TargetType="{x:Type DataGridCell}">
                        <Setter Property="ContextMenu" Value="{StaticResource ContextMenu}">
                                               </Setter>
                    </Style>
                </DataGrid.CellStyle>
                <DataGrid.Columns>
                    <DataGridTextColumn Header="A" Binding="{Binding}">
    
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
