    <ComboBox Name="Test">  
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <EventSetter Event="MouseMove" Handler="TestMenuItem_MouseMove"/>
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBoxItem>Item1</ComboBoxItem>  
        <ComboBoxItem>Item2</ComboBoxItem>
    </ComboBox> 
