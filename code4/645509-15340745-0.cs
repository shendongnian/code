    <ContextMenu x:Shared="False" x:Key="ListViewContextMenu>
                    <MenuItem Command="{Binding Path=Command}"
                              CommandParameter="AddNew">
                        <MenuItem.Header>
                            <TextBlock Text="{x:Static p:TextResources.New}" />
                        </MenuItem.Header>
                    </MenuItem>
                    <MenuItem Command="{Binding Path=Command}"
                              CommandParameter="Delete">
                        <MenuItem.Header>
                            <TextBlock Text="{x:Static p:TextResources.Delete}" />
                        </MenuItem.Header>
                    </MenuItem>
                </ContextMenu>
    
    <Style x:Key="ListViewItemContainerStyle"
           TargetType="ListViewItem">
        <Setter Property="ContextMenu" Value="{StaticResource ListViewContextMenu}"/>
