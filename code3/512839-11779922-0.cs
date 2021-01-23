    <Style TargetType="{x:Type TextBox}">
                    <Setter Property="RenderTransform">
                        <Setter.Value>
                            <RotateTransform Angle="-90"></RotateTransform>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="IsFocused" Value="True">
                            <Setter Property="RenderTransform">
                                <Setter.Value>
                                    <RotateTransform Angle="0"></RotateTransform>
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
