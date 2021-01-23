    <MultiTrigger>
      <MultiTrigger.Conditions>
        <Condition Property="IsSelected" Value="true"/>
        <Condition Property="Selector.IsSelectionActive" Value="false"/>
      </MultiTrigger.Conditions>
      <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
      <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
    </MultiTrigger>
