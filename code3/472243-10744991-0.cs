    <Window.Resources>
        <Style TargetType="ListBoxItem">
            <!-- disable default selection highlight -->
            <Style.Resources>
                <!-- SelectedItem with focus -->
                <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" 
                                 Color="Transparent" />
                <!-- SelectedItem without focus -->
                <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" 
                                 Color="Transparent" />
            </Style.Resources>
            <Setter Property="FocusVisualStyle" Value="{x:Null}" />
        </Style>
        <Style x:Key="TitleStyle" TargetType="{x:Type TextBlock}">
            <Setter Property="Foreground" Value="LightGray"/>
            <Style.Triggers>
                <DataTrigger Value="True" Binding="{Binding Path=IsSelected, 
                             RelativeSource={RelativeSource Mode=FindAncestor, 
                                 AncestorType={x:Type ListBoxItem}}}">
                    <Setter Property="Foreground" Value="DarkGray"/>
                    <Setter Property="FontWeight" Value="Bold"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.DataContext>
            <local:MyTabViewModel/>
        </Grid.DataContext>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        
        <ListBox Grid.Row="0" ItemsSource="{Binding Items}" 
                              SelectedItem="{Binding SelectedItem}" 
                              BorderBrush="{x:Null}" BorderThickness="0">
            <ListBox.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ListBox.ItemsPanel>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Title}" Margin="5" 
                               Style="{StaticResource TitleStyle}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        
        <ContentControl Grid.Row="1" Content="{Binding SelectedItem.Content}"/>
    </Grid>
