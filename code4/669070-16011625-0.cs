    <ComboBox x:Name="cb">
        <ComboBox.Items>
            <ComboBoxItem Content="(None)">
                <ComboBoxItem.Triggers>
                    <EventTrigger RoutedEvent="Selector.Selected">
                        <BeginStoryboard>
                            <Storyboard Storyboard.TargetName="cb" Storyboard.TargetProperty="SelectedItem">
                                <ObjectAnimationUsingKeyFrames Duration="0:0:0">
                                    <DiscreteObjectKeyFrame Value="{x:Null}" />
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>                               
                    </EventTrigger>
                </ComboBoxItem.Triggers>
            </ComboBoxItem>
            <ComboBoxItem>First Item</ComboBoxItem>
            <ComboBoxItem>Second Item</ComboBoxItem>
        </ComboBox.Items>
    </ComboBox>
