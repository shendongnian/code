    <DockPanel>
        <Menu DockPanel.Dock="Top">
            <MenuItem Header="Edit">
                <MenuItem Command="Cut" Header="_Cut" />
                <MenuItem Command="Copy" Header="C_opy" />
                <MenuItem Command="Paste" Header="_Paste" />
            </MenuItem>
        </Menu>
        <ToolBarTray DockPanel.Dock="Top">
            <ToolBar>
                <Button Command="Cut" Content="Cut" />
                <Button Command="Copy" Content="Copy" />
                <Button Command="Paste" Content="Paste" />
            </ToolBar>
        </ToolBarTray>
        <TextBox SpellCheck.IsEnabled="True" />
    </DockPanel>
