        <Style x:Key="GroupItemStyle" TargetType="{x:Type GroupItem}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type GroupItem}">
                            <StackPanel Orientation="Horizontal" >
                                <Border BorderThickness="0">
                                    <Grid HorizontalAlignment="Center" VerticalAlignment="Center">
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto"/>
                                            <ColumnDefinition Width="Auto"/>
                                        </Grid.ColumnDefinitions>
                                        <Border BorderThickness="1" MinWidth="150">
                                            <Grid HorizontalAlignment="Center" VerticalAlignment="Center">
                                                <ContentPresenter Content="{Binding Name}" >
                                                </ContentPresenter>
                                            </Grid>
                                        </Border>
                                        <Border BorderThickness="0" Grid.Column="1">
                                            <Grid HorizontalAlignment="Center" VerticalAlignment="Center">
                                                <ItemsPresenter/>
                                            </Grid>
                                        </Border>
                                    </Grid>
                                </Border>
                            </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
