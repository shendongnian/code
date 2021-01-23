                <Style TargetType="{x:Type TreeViewItem}">
                    <Style.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsKeyboardFocusWithin" Value="True"></Condition>
                                <Condition Property="HasItems" Value="False"></Condition>
                            </MultiTrigger.Conditions>
                            <MultiTrigger.Setters>
                                <Setter Property="IsSelected" Value="True"></Setter>
                            </MultiTrigger.Setters>
                        </MultiTrigger>
                    </Style.Triggers>
                </Style>
