    <MultiTrigger>
        <MultiTrigger.Conditions>
            <Condition Property="IsActive" Value="True"/>
        </MultiTrigger.Conditions>
        <MultiTrigger.EnterActions>
            <BeginStoryboard Storyboard="{StaticResource StoryBoard1}"/>
        </MultiTrigger.EnterActions>
        <MultiTrigger.ExitActions>
            <BeginStoryboard Storyboard="{StaticResource StoryBoard2}"/>
        </MultiTrigger.ExitActions>
    </MultiTrigger>
