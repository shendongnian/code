    xmlns:theme="clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero"
    
    ...
    
    <Style x:Key="{x:Static GridView.GridViewStyleKey}"
           TargetType="{x:Type ListView}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ListView}">
                    <theme:ListBoxChrome Name="Bd"
                                         BorderThickness="{TemplateBinding BorderThickness}"
                                         BorderBrush="{TemplateBinding BorderBrush}"
                                         Background="{TemplateBinding Background}"
                                         RenderFocused="{TemplateBinding IsKeyboardFocusWithin}"
                                         SnapsToDevicePixels="true">
                        <ScrollViewer Style="{DynamicResource {x:Static GridView.GridViewScrollViewerStyleKey}}"
                                      Padding="{TemplateBinding Padding}">
                            <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                        </ScrollViewer>
                    </theme:ListBoxChrome>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsGrouping"
                                 Value="true">
                            <Setter Property="ScrollViewer.CanContentScroll"
                                    Value="false"/>
                        </Trigger>
                        <Trigger Property="IsEnabled"
                                 Value="false">
                            <Setter TargetName="Bd"
                                    Property="Background"
                                    Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
