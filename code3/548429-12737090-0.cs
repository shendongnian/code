    <GridViewColumn>
        <!-- Show context menu for this column --> 
        <GridViewColumn.CellTemplate>    
            <DataTemplate>
                <Grid>
                    <ContextMenuService.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="Menu Item" />
                        </ContextMenu>
                    </ContextMenuService.ContextMenu>
                </Grid>
            </DataTemplate>
        </GridViewColumn.CellTemplate>    
    </GridViewColumn>
