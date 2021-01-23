    <TabControl>
            <TabItem>
                <TabItem.Header>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="Auto" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0">Output</TextBlock>
                        <Button Grid.Column="1" Name="button_close" Click="button_close_Click">
                      <Button.Template>
                                <ControlTemplate TargetType="Button">
                                    <Path Data="M0,0 L8,8 M8,0 L0,8" StrokeThickness="3" VerticalAlignment="Center" Margin="5,4,0,2">
                                        <Path.Style>
                                            <Style TargetType="{x:Type Path}">
                                                <Style.Triggers>
                                                    <Trigger Property="IsMouseOver" Value="False">
                                                        <Setter Property="Stroke" Value="LightGray" />
                                                    </Trigger>
                                                    <Trigger Property="IsMouseOver" Value="True">
                                                        <Setter Property="Stroke" Value="Black" />
                                                    </Trigger>
                                                </Style.Triggers>
                                            </Style>
                                        </Path.Style>
                                    </Path>
                                </ControlTemplate>
                            </Button.Template>
                        </Button>
                    </Grid>
                    
                    
                </TabItem.Header>
             <TabItem.Content>
             </TabItem.Content>
