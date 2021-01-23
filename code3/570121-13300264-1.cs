    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsSelected" Value="True"/>
            <Condition Property="IsSelectionActive" Value="False"/>
        </MultiTrigger.Conditions>
        <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
    </MultiTrigger>
