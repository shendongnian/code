    <ListBox.ItemContainerStyle>
        <Style TargetType="{x:Type ListBoxItem}">
            <EventSetter Event="PreviewMouseDown" Handler="ListBoxItem_PreviewMouseDown" />
            <Style.Triggers>
                <Trigger Property="IsSelected" Value="True">
                    <Setter Property="FontWeight" Value="Bold" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </ListBox.ItemContainerStyle>
    private void ListBoxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount < 2)
            e.Handled = true;
    }
