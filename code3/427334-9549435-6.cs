            <!--Defines a menu-->
            <ContextMenu x:Key="MyElementMenu">
                <MenuItem Header="Delete" Click="MenuItemDelete_Click"/>
            </ContextMenu>
                
            <!--Sets a menu to each item-->
            <Style TargetType="{x:Type ListBoxItem}">
                 <Setter Property="ContextMenu" Value="{StaticResource MyElementMenu}"/>
            </Style>
                
        </ListBox.Resources>
        <ListBoxItem>...</ListBoxItem>
        <ListBoxItem>...</ListBoxItem>
        <ListBoxItem>...</ListBoxItem>
    </ListBox>
