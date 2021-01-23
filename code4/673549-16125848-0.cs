    <MultiTrigger>
      <MultiTrigger.Conditions>
        <Condition Property="IsSelected"
                    Value="true" />
        <Condition Property="Selector.IsSelectionActive"
                    Value="false" />
      </MultiTrigger.Conditions>
      <Setter TargetName="Bd"
              Property="Background"
              Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}" />
      <Setter Property="Foreground"
              Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}" />
    </MultiTrigger>
