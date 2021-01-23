    <UserControl x:Class="WpfApplication1.UserControl1">
        <DockPanel>
            <DockPanel.CommandBindings>
                <CommandBinding Command="ApplicationCommands.New"
                                CanExecute="OnCanExecuteNew"
                                Executed="OnExecuteNew"/>
            </DockPanel.CommandBindings>
            <ToolBarTray DockPanel.Dock="Top">
                <ToolBar>
                    <Button Command="ApplicationCommands.New" Content="New"/>
                </ToolBar>
            </ToolBarTray>
            <ContentPresenter Content="{Binding SomeProperty}" />
        </DockPanel>
    </UserControl>
