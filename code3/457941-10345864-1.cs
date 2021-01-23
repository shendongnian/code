    <StackPanel>
        <Rectangle Style="{DynamicResource key1}" Height="200" Width="200" x:Name="rect1"/>
        <Button Click="Button_Click" Content="Click"/>
    </StackPanel>
    Style style = new Style {TargetType = typeof(Rectangle)};
    style.Setters.Add(new Setter(Shape.FillProperty, Brushes.Red));
    style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
    Application.Current.Resources["key1"] = style;
