    <Page.Resources>
        <Style x:Key="ItemStyle" TargetType="ListBoxItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListBoxItem">
                        <ContentPresenter/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        
        <Style x:Key="Selected" TargetType="{x:Type TextBlock}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Path=IsSelected, 
                             RelativeSource={RelativeSource Mode=FindAncestor, 
                             AncestorType={x:Type ListBoxItem}}}" Value="True">
                    <Setter Property="Background" 
                            Value="{x:Static SystemColors.HighlightBrush}"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
        
        <DataTemplate x:Key="ItemTemplate" DataType="{x:Type ViewModel:DataItem}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="auto" SharedSizeGroup="c1"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="{Binding Name}" Margin="0,0,5,0"/>
                <TextBlock Style="{StaticResource Selected}" Grid.Column="1" 
                            Text="{Binding Description}"/>
            </Grid>
        </DataTemplate>
    </Page.Resources>
    
    <Page.DataContext>
        <Samples:Page3ViewModel/>
    </Page.DataContext>
    
    <Grid>
        <ListBox 
            Grid.IsSharedSizeScope="True"
            SelectedIndex="2"
            HorizontalContentAlignment="Stretch"
            ItemsSource="{Binding Items}" 
            ItemContainerStyle="{StaticResource ItemStyle}"
            ItemTemplate="{StaticResource ItemTemplate}"/>
    </Grid>
