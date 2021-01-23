    <DataTemplate x:Key="DummyItemTemplate">
                <TextBlock Text="{Binding Name}">
                    <TextBlock.ContextMenu>
                        <ContextMenu> 
                            <i:Interaction.Triggers>
                                <i:EventTrigger EventName="Opened">
                                    <i:InvokeCommandAction Command="{Binding ShowMoreOptions}" />
                                </i:EventTrigger>
                                <i:EventTrigger EventName="Closed">
                                    <i:InvokeCommandAction Command="{Binding HideMoreOptions}" />
                                </i:EventTrigger>
                            </i:Interaction.Triggers>
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
            </DataTemplate>
