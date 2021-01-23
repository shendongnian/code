    <ItemsControl ItemsSource="{Binding Path=CustomerTankDayStructure,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"
                                                  Grid.Column="1"
                                                  Grid.Row="2">
                                        <ItemsControl.ItemsPanel>
                                            <ItemsPanelTemplate>
                                                <Grid helper:EnterKeyTraversal.IsEnabled="True"
                                                      KeyboardNavigation.TabNavigation="Local">
                                                    <Grid.ColumnDefinitions>
                                                        <ColumnDefinition Width="0" />
                                                        [...]
                                                        <ColumnDefinition Width="30" />
                                                    </Grid.ColumnDefinitions>
                                                    <Grid.RowDefinitions>
                                                        <RowDefinition Height="0" />
                                                        <RowDefinition Height="30" />
                                                        [...]
                                                        <RowDefinition Height="30" />
                                                    </Grid.RowDefinitions>
                                                </Grid>
                                            </ItemsPanelTemplate>
                                        </ItemsControl.ItemsPanel>
                                        <ItemsControl.ItemContainerStyle>
                                            <Style>
                                                <Setter Property="Grid.Column" Value="{Binding Path=DoW}" />
                                                <Setter Property="Grid.Row" Value="{Binding Path=HoD}" />
                                            </Style>
                                        </ItemsControl.ItemContainerStyle>
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <Border BorderThickness="0,0,1,1"
                                                        Style="{StaticResource ResourceKey=DefaultBorder}">
                                                    <TextBox BorderThickness="0"
                                                             MaxLength="3"
                                                             Style="{StaticResource ResourceKey=EditableTextBoxWithoutWarningForTanks}"
                                                             TextAlignment="Center"
                                                             VerticalContentAlignment="Center"
                                                             IsTabStop="True">
                                                        <TextBox.TabIndex>
                                                            <MultiBinding Converter="{StaticResource ResourceKey=CustomerTankTabIndexConverter}">
                                                                <Binding Path="DoW" />
                                                                <Binding Path="HoD" />
                                                            </MultiBinding>
                                                        </TextBox.TabIndex>
                                                        <TextBox.Text>
                                                            <Binding Path="Value"
                                                                     Mode="TwoWay"
                                                                     NotifyOnValidationError="True"
                                                                     TargetNullValue=""
                                                                     UpdateSourceTrigger="PropertyChanged">
                                                                <Binding.ValidationRules>
                                                                    <validator:Int32Validator Mandatory="True" 
                                                                                              Min="0" 
                                                                                              Max="100" />
                                                                </Binding.ValidationRules>
                                                            </Binding>
                                                        </TextBox.Text>
                                                    </TextBox>
                                                </Border>
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
