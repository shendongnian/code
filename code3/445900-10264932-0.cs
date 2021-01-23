    <CheckBox Content="Select" Width="100" Height="22">
            <CheckBox.Style>
                <Style TargetType="{x:Type CheckBox}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate>
                                <ComboBox>
                                    <ComboBoxItem x:Name="TrueComboBoxItem" Content="True" IsSelected="{Binding IsChecked, RelativeSource={RelativeSource AncestorType=CheckBox}, UpdateSourceTrigger=PropertyChanged}" />
                                    <ComboBoxItem x:Name="FalseComboBoxItem" Content="False" />
                                    
                                </ComboBox>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>                     
            </CheckBox.Style>
        </CheckBox>
