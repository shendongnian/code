     <DataTemplate DataType="{x:Type vm:MyControlViewModel}">
        <ContentControl>
            <ContentControl.ToolTip>
               <!-- TOOLTIP CODE GOES HERE -->
            </ContentControl.ToolTip>
            <ContentControl.InputBindings>
                <!-- INPUT BINDINGS CODE GOES HERE -->
            </ContentControl.InputBindings>
            <ContentControl.ContextMenu>
                <!-- CONTEXT MENU CODE GOES HERE -->
            </ContentControl.ContextMenu>
            <ContentControl.Style>
                <Style>
                    <Style.Triggers>
                        <DataTrigger Binding="Visibility" Value="0">
                            <Setter Property="ContentControl.Content">
                                <Setter.Value>
                                    <Ellipse Width="50" Height="50" Opacity="0.5">
                                        <Ellipse.Fill>
                                            <LinearGradientBrush>
                                                <GradientStopCollection>
                                                    <GradientStop Color="Red" Offset="0" />
                                                    <GradientStop Color="DarkRed" Offset="0.8" />
                                                </GradientStopCollection>
                                            </LinearGradientBrush>
                                        </Ellipse.Fill>
                                    </Ellipse>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="Visibility" Value="100">
                            <Setter Property="ContentControl.Content">
                                <Setter.Value>
                                    <Image Source="{Binding Icon}" Opacity="{Binding Visible, Converter={StaticResource VisibilityConverter}}" />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ContentControl.Style>
        </ContentControl>
    </DataTemplate>
