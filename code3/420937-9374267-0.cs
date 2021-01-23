    <Window.Resources>
            <Style TargetType="DataGridRow">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <ContextMenu.Template>
                                <ControlTemplate>
                                    <TextBox Text="{Binding <the property with which column is bound to>}" Height="30" Width="40" />
                                </ControlTemplate>
                            </ContextMenu.Template>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
