    <Trigger Property="IsMouseOver" Value="True">
        <Trigger.EnterActions>
            <BeginStoryboard>
                <Storyboard AutoReverse="True"> // AutoReverse
                    <ColorAnimation Duration="0:0:0.5"
                                    Storyboard.TargetName="MyButton"
                                    Storyboard.TargetProperty="Background.Color" 
                                    To="Blue"/>
                </Storyboard>
            </BeginStoryboard>
        </Trigger.EnterActions>
    </Trigger>
