            <DataGrid Name="grid">
                <DataGrid.Resources>
                    <Style TargetType="DataGridRow">
                        <Setter Property="ContextMenu">
                            <Setter.Value>
                                <ContextMenu>
                                    <MenuItem Header="Copy Row" />
                                    <MenuItem Header="Paste Row" />
                                </ContextMenu>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGrid.Resources>
                <DataGrid.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="Copy Grid" />
                        <MenuItem Header="Paste Grid" />
                    </ContextMenu>
                </DataGrid.ContextMenu>
            </DataGrid>
