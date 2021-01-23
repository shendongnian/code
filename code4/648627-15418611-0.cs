    <Setter Property="ToolTip">
                        <Setter.Value>
                            <ToolTip DataContext="{Binding PlacementTarget, RelativeSource={RelativeSource Self}}">
                                <Grid Margin="5">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto"/>
                                        <ColumnDefinition Width="*"/>
                                    </Grid.ColumnDefinitions>
                                    <TextBlock Grid.Column="1" Margin="4, 0,0,0" Text="{Binding Path=(Validation.Errors)[0].ErrorContent}"></TextBlock>
                                </Grid>
                            </ToolTip>
                        </Setter.Value>
                    </Setter>
