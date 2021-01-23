    <DataTemplate.Triggers>
        <!-- Highlight row on mouse over, and highlight the delete button. -->
        <EventTrigger RoutedEvent="ItemsControl.MouseEnter">
            <EventTrigger.Actions>
                <BeginStoryboard>
                    <Storyboard>
                        <!-- On mouse over, flicker the row to highlight it.-->
                        <DoubleAnimation
                            Storyboard.TargetProperty="Opacity"
                            From="0.5" 
                            To="1" 
                            Duration="0:0:0.250"  
                            FillBehavior="Stop"/>
                        <!-- Highlight the delete button with red. -->
                        <ColorAnimation
                            To="Red"
                            Storyboard.TargetName="MyDeleteRowButton"
                            Storyboard.TargetProperty="(Stroke).(SolidColorBrush.Color)"
                            Duration="0:0:0.100" 
                            FillBehavior="HoldEnd"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger.Actions>
        </EventTrigger>
        <!-- Grey out the delete button. -->
        <EventTrigger RoutedEvent="ItemsControl.MouseLeave">
            <EventTrigger.Actions>
                <BeginStoryboard>
                    <Storyboard>
                        <!-- Space is precious: "delete" button appears only on a mouseover. -->
                        <ColorAnimation
                            To="Gray"
                            Storyboard.TargetName="MyDeleteRowButton"
                            Storyboard.TargetProperty="(Stroke).(SolidColorBrush.Color)"
                            Duration="0:0:0.100" 
                            FillBehavior="HoldEnd"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger.Actions>
        </EventTrigger>
    </DataTemplate.Triggers>
