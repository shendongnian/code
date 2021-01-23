         <Style.Triggers>
            <Trigger Property="Role" Value="Padding">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="GridViewColumnHeader">
                            <Border x:Name="HeaderBorder" BorderBrush="{DynamicResource BRUSH_ListView_HeaderBorderBorderBrush_ALL}" BorderThickness="0,1,0,1" Background="{DynamicResource BRUSH_ListView_HeaderBorderBackground_UP}">
                                <Border x:Name="borderHighlight" BorderBrush="{DynamicResource BRUSH_ListView_borderHighlightBorderBrush_UP}" BorderThickness="0,1,0,0" />
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="Height" Value="Auto">
                                    <Setter Property="MinHeight" Value="20"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers> 
