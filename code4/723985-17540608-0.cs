            <Style x:Key="HoldOrResumeButton" TargetType="{x:Type ToggleButton}" BasedOn="{StaticResource {x:Type ToggleButton}}">
                <Setter Property="Content">
                    <Setter.Value>
                        <TextBlock Text="Hold"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked, RelativeSource={RelativeSource Mode=Self}}" Value="True">
                        <Setter Property="Content">
                            <Setter.Value>
                                <TextBlock Text="Resume"/>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
