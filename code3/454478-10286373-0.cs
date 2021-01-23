    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsMouseOver" Value="True"/>
            <Condition Property="MinHeight"
                       Value="{StaticResource ToolbarCollapsedHeight_YesIB}"/>
        </MultiTrigger.Conditions>
        <MultiTrigger.ExitActions>
            <BeginStoryboard Storyboard="{StaticResource ToolbarCollapse_YesIB}" />
        </MultiTrigger.ExitActions>
    </MultiTrigger>
    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsMouseOver" Value="True"/>
            <Condition Property="MinHeight"
                       Value="{StaticResource ToolbarCollapsedHeight_NoIB}"/>
        </MultiTrigger.Conditions>
        <MultiTrigger.ExitActions>
            <BeginStoryboard Storyboard="{StaticResource ToolbarCollapse_NoIB}" />
        </MultiTrigger.ExitActions>
    </MultiTrigger>
