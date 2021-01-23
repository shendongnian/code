    <ListBox ItemsSource="{Binding}" x:Name="lst" Height="500" Width="500">
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate>
                        <Canvas IsItemsHost="True"/>
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
                <ListBox.ItemContainerStyle>
                    <Style TargetType="ListBoxItem">
                        <Setter Property="FocusVisualStyle">
                            <Setter.Value>
                                <Style TargetType="Control">
                                    <Setter Property="Opacity" Value="0"/>
                                </Style>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="ListBoxItem">
                                    <Line X1="{Binding X1}" Y1="{Binding Y1}"
                                          X2="{Binding X2}" Y2="{Binding Y2}" 
                                          StrokeThickness="{Binding Thickness}"
                                          Opacity="{Binding Opacity}"
                                          x:Name="Line">
                                        <Line.Stroke>
                                            <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                                                <GradientStop Color="{Binding Color1}" Offset="0"/>
                                                <GradientStop Color="{Binding Color2}" Offset="1"/>
                                            </LinearGradientBrush>
                                        </Line.Stroke>
                                    </Line>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsSelected" Value="true">
                                            <Setter Property="Effect" TargetName="Line">
                                                <Setter.Value>
                                                    <DropShadowEffect Color="CornflowerBlue" ShadowDepth="3" BlurRadius="10"/>
                                                </Setter.Value>
                                            </Setter>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListBox.ItemContainerStyle>
            </ListBox>
