    <Style TargetType="TextBox">
                <Style.Resources>
                    <Style TargetType="ListViewItem">
                        <Setter Property="Margin" Value="0"/>
                        <Setter Property="Padding" Value="0"/>
                        <Setter Property="IsEnabled" Value="False"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Border BorderThickness="0,0,0,2" BorderBrush="Black" >
                                    <ContentPresenter Content="{Binding}" />
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Style.Resources>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="TextBox">
                            <ListView Focusable="False" ItemsSource="{Binding Text, Converter={local:TextLineConverter}, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource TemplatedParent}}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
