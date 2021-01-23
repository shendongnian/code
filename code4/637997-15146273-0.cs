    <ControlTemplate TargetType="{x:Type Button}" x:Key="BoutonImageEtTexte">
        <Button Grid.Column="2" BorderBrush="Transparent" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" HorizontalAlignment="Center" VerticalAlignment="Center" Width="90" Height="27" >
            <Button.Content>
                <StackPanel Orientation="Horizontal">
                    <Border CornerRadius="3">
                        <ContentPresenter/>
                        <Border.Style>
                            <Style TargetType="{x:Type Border}">
                                <Setter Property="Background" Value="#58585a" />
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="Background" Value="{StaticResource DegradeCouleurTheme}" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </Border.Style>
                    </Border>
                    <Label>
                        <Label.Content>Fichiers joints</Label.Content>
                        <Label.Foreground>white</Label.Foreground>
                        <Label.VerticalAlignment>center</Label.VerticalAlignment>
                        <Label.HorizontalAlignment>center</Label.HorizontalAlignment>
                    </Label>
                </StackPanel>
            </Button.Content>
            <Button.Style>
                <Style TargetType="{x:Type Button}" >
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type Button}" >
                                <ContentPresenter />
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Button.Style>
        </Button>
    </ControlTemplate>
