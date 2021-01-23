    <Grid>
        <TreeView Margin="0,40,0,0">
            <TreeViewItem Header="Level 1">
                <TreeViewItem Header="Level 2" />
            </TreeViewItem>
            
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="IsExpanded" Value="False" />
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="IsExpanded" Value="True" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TreeView.ItemContainerStyle>
        </TreeView>
    </Grid>
