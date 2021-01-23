    <YourControl>
      <YourControl.Resources>
         <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
      </YourControl.Resources>
      <YourControl.ContextMenu>
       <ContextMenu Visibility="{Binding IsEnable,
                    Converter={StaticResource BooleanToVisibilityConverter}}">
          <MenuItem Header="MenuItem1"/>
          <MenuItem Header="MenuItem2"/>
          <MenuItem Header="MenuItem3"/>
        </ContextMenu>
      </YourControl.ContextMenu>
    </YourControl>
