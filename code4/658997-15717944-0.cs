    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding Path=GroupStyle}" Value="GroupStyle1"/>
            <Condition Binding="{Binding Path=IsGrouped}" Value="False"/>
        </MultiDataTrigger.Conditions>
        <MultiDataTrigger.EnterActions>
            <BeginStoryboard x:Name="BeginStoryboard_TurnToUnselectedStyle1" Storyboard="{StaticResource Storyboard_TurnToUnselectedStyle1}"/>
        </MultiDataTrigger.EnterActions>
        <MultiDataTrigger.ExitActions>
            <RemoveStoryboard BeginStoryboardName="BeginStoryboard_TurnToUnselectedStyle1"/>
        </MultiDataTrigger.ExitActions>
    </MultiDataTrigger>
