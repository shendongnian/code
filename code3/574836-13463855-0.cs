    <HierarchicalDataTemplate  x:Key="ChildTemplate">
                <StackPanel Orientation="Horizontal">
                    <StackPanel.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="Copy" CommandParameter="{Binding CopyTag}">
                            </MenuItem>
                            <MenuItem Header="Paste" CommandParameter="{Binding PasteTag}">
                            </MenuItem>
                            <ContextMenu.ItemContainerStyle>
                                <Style TargetType="MenuItem">
                                    <Setter Property="Command" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.CopyPaste}"/>
                                </Style>
                            </ContextMenu.ItemContainerStyle>
                        </ContextMenu>
                    </StackPanel.ContextMenu>
                    <Image Source="/Images/Child.png" Stretch="None" VerticalAlignment="Center" HorizontalAlignment="Center" Style="{StaticResource TreeIconStyle}"/>
                    <TextBlock Text="{Binding Path=Label}" Style="{StaticResource TreeTextStyle}" ToolTip="{Binding Path=Description}" Tag="{Binding Path=Tag}">
                    </TextBlock>
                </StackPanel>
            </HierarchicalDataTemplate>
