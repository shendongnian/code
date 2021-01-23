    <TextBlock>
                <TextBlock.ContextMenu>
                    <ContextMenu>
                        <ContextMenu.InputBindings>
                            <KeyBinding Modifiers="Shift" Key="Shift" Command="{Binding ShowMoreOptions}" />
                        </ContextMenu.InputBindings>
                        <MenuItem Command="{Binding SendToRecycleBin}" Header="Delete" />
                        <MenuItem Command="{Binding Delete}" Header="Permanently Delete">
                            <MenuItem.Style>
                                <Style TargetType="MenuItem">
                                    <Setter Property="Visibility" Value="Collapsed" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsVisibleDelete}" Value="True">
                                            <Setter Property="Visibility" Value="Visible" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </MenuItem.Style>    
                        </MenuItem>
                    </ContextMenu>
                </TextBlock.ContextMenu>
            </TextBlock>
