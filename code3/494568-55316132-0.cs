                    <TextBox.Background >
                        <Binding Path="HasInitiativeChanged" Converter="{StaticResource changedToBrushConverter}">
                            <Binding.ConverterParameter>
                                <x:Array Type="Brush">
                                    <SolidColorBrush Color="{DynamicResource ThemeTextBackground}"/>
                                    <SolidColorBrush Color="{DynamicResource SecondaryColorBMedium}"/>
                                </x:Array>
                            </Binding.ConverterParameter>
                        </Binding>
                    </TextBox.Background>
