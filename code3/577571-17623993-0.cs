     // Set to visible on load
     Loaded += delegate
     {
         Dispatcher.BeginInvoke(new Action(() => Visibility = Visibility.Visible));
     };
     <!-- By default set to Collapsed -->
     <Style TargetType="{x:Type MyCustomTypeThatIsMisbehaving}">
        <Setter Property="Visibility" Value="Collapsed"/>
     </Style>
