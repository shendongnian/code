    <TextBox>
        <TextBox.Style>                
            <Style TargetType="TextBox">
                <Setter Property="Text">
                    <Setter.Value>
                        <Binding Path="MinStepDiff" UpdateSourceTrigger="PropertyChanged">
                            <Binding.ValidationRules>
                                <local:ImpellerArgsRule IsCanBeZero="false" />
                            </Binding.ValidationRules>
                        </Binding>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedIndex, ElementName=cb}" Value="1">
                        <Setter Property="Text">
                            <Setter.Value>
                                <Binding Path="MinTolerance" UpdateSourceTrigger="PropertyChanged" />
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TextBox.Style>
    </TextBox>
