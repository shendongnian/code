     <DataGrid.Triggers>
        <EventTrigger RoutedEvent="DataGrid.SelectionChanged" > // SelectionChanged Event
            <BeginStoryboard>
                <Storyboard >
                    <Int32AnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="tabControl1" Storyboard.TargetProperty="SelectedIndex"> // set target control and target property
                        <SplineInt32KeyFrame KeyTime="00:00:00" Value="1"/> // Value = TabControl Selected index you want to show
                    </Int32AnimationUsingKeyFrames>
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
    </DataGrid.Triggers>
