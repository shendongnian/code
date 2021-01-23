    <ContextMenu ItemsSource="{Binding MyCommandList}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Header" Value="{Binding Displayname}" />
                <Setter Property="Command" Value="{Binding MyContextMenuCommand }" />
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
