    <ToggleButton>
                <ToggleButton.Template>
                    <ControlTemplate TargetType="ToggleButton">
                        <Border>
                            <Image>
                                <Image.Source>
                                    <Binding Path="IsChecked" RelativeSource="{RelativeSource TemplatedParent}">
                                        <Binding.Converter>
                                            <local:BooleanSwitchConverter 
                                                TrueValue="1.jpg" 
                                                FalseValue="2.jpg"/>
                                        </Binding.Converter>
                                    </Binding>
                                </Image.Source>
                            </Image>
                        </Border>
                    </ControlTemplate>
                </ToggleButton.Template>
            </ToggleButton>
