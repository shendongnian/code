    <ComboBox Height="23" Name="comboBox1" Width="120" ItemsSource="{Binding OCString,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged,RelativeSource={RelativeSource AncestorType=Window}}" SelectedValue="{Binding Selected,Mode=TwoWay,RelativeSource={RelativeSource AncestorType=Window},UpdateSourceTrigger=PropertyChanged}">
            <ComboBox.Style>
                <Style TargetType="{x:Type ComboBox}">
                    <Style.Triggers>
                        <Trigger Property="SelectedIndex" Value="-1">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <ComboBox Text="Select an Item" IsReadOnly="True" IsEditable="True" ItemsSource="{Binding OCString,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged,RelativeSource={RelativeSource AncestorType=Window}}" SelectedValue="{Binding Selected,Mode=TwoWay,RelativeSource={RelativeSource AncestorType=Window},UpdateSourceTrigger=PropertyChanged}"/>
       
        </ControlTemplate>
        </Setter.Value>
        </Setter>
                        </Trigger>
                    </Style.Triggers>
        </Style>
        </ComboBox.Style>
        </ComboBox>
