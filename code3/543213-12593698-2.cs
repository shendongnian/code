    <StackPanel>
        <StackPanel>
            <Label FontSize="28" Content="Sales">
            </Label>
        </StackPanel>
        <Grid>
            <Grid.ColumnDefinitions>                
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="Auto" />
            </Grid.ColumnDefinitions>
            <StackPanel Grid.Column="0" HorizontalAlignment="Center">
                <Label FontSize="15" Content="Enter Amount" Height="26" Width="168" />
                <Separator Width="168" />
            </StackPanel>
             <Expander Grid.Column="1" ExpandDirection="Left" HorizontalAlignment="Right" VerticalAlignment="Stretch">
                <Expander.Style>
                    <Style TargetType="Expander">
                        <Setter Property="IsExpanded" Value="False" />
                        <Setter Property="Header">
                            <Setter.Value>
                                <TextBlock Text="Less">
                                    <TextBlock.LayoutTransform>
                                        <RotateTransform Angle="-90"/>
                                    </TextBlock.LayoutTransform>
                                </TextBlock>
                            </Setter.Value>
                        </Setter>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsExpanded,RelativeSource={RelativeSource Self}}" Value="True">
                                <Setter Property="Header">
                                    <Setter.Value>
                                        <TextBlock Text="More">
                                            <TextBlock.LayoutTransform>
                                                <RotateTransform Angle="-90"/>
                                            </TextBlock.LayoutTransform>
                                        </TextBlock>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Expander.Style>
                <Expander.Content>
                    <StackPanel>
                        <DataGrid ItemsSource="{Binding Products}">
                        </DataGrid>
                    </StackPanel>
                </Expander.Content>
            </Expander>
        </Grid>
    </StackPanel>
