    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <ItemsControl ItemsSource="{Binding}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid Width="600">
                        <Grid.Resources>
                            <Style TargetType="Border">
                                <Setter Property="BorderBrush" Value="White" />
                                <Setter Property="BorderThickness" Value="1" />
                                <Setter Property="Margin" Value="0" />
                            </Style>
                            <Style TargetType="TextBlock">
                                <Setter Property="TextWrapping" Value="Wrap" />
                                <Setter Property="FontSize" Value="29.333" />
                                <Setter Property="HorizontalAlignment" Value="Center" />
                                <Setter Property="VerticalAlignment" Value="Center" />
                                <Setter Property="Margin" Value="0" />
                            </Style>
                        </Grid.Resources>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        
                        <!-- first record -->
                        <Border Grid.Column="0">
                            <TextBlock Text="{Binding One}" />
                        </Border>
                        <!-- second record -->
                        <Border Grid.Column="1">
                            <TextBlock Text="{Binding Two}" />
                        </Border>
                        <!-- third record -->
                        <Border Grid.Column="2">
                            <TextBlock Text="{Binding Three}" />
                        </Border>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
