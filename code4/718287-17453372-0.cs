    <Trigger Property="IsEnabled" Value="false">
                    <Setter Property="Validation.ErrorTemplate">
                        <Setter.Value>
                            <ControlTemplate>
                                <DockPanel>
                                    <Border BorderBrush="Gray" BorderThickness="0">
                                        <AdornedElementPlaceholder/>
                                    </Border>
                                </DockPanel>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Trigger>
