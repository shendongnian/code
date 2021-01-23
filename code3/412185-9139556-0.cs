    <ControlTemplate.Triggers>
        <Trigger Property="IsSelected" Value="True">
            <Trigger.EnterActions>
                <BeginStoryboard Name="BeginSelected" Storyboard="{StaticResource SelectTab}" />
            </Trigger.EnterActions>
        </Trigger>
    </ControlTemplate.Triggers>
