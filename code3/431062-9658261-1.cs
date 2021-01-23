    <Page.Resources>
        <ResourceDictionary>
    
            <Style x:Key="NullSelectionStyle" TargetType="ListBoxItem">
                <Style.Resources>
                    <!-- SelectedItem with focus -->
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent" />
                    <!-- SelectedItem without focus -->
                    <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="Transparent" />
                    <!-- SelectedItem text foreground -->
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="{DynamicResource {x:Static SystemColors.ControlTextColorKey}}" />
                </Style.Resources>
                <Setter Property="FocusVisualStyle" Value="{x:Null}" />
            </Style>
    
            <Style x:Key="ListBoxSelectableTextBox" TargetType="{x:Type TextBox}">
                <Setter Property="IsHitTestVisible" Value="False" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListBoxItem}, AncestorLevel=1}}" Value="True">
                        <Setter Property="IsHitTestVisible" Value="True" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ResourceDictionary>
    </Page.Resources>
    <Grid>
        <ListBox ItemsSource="{Binding Departments}" HorizontalContentAlignment="Stretch">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBox Margin="5" Style="{StaticResource ListBoxSelectableTextBox}" Text="{Binding Name}" BorderBrush="{x:Null}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
