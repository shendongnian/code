    <StackPanel Orientation="Vertical">
        <wpfProj:ExtendedCombobBox 
           SelectedIndex="{Binding Path=ComboBoxSelectedIndex, 
                                  Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
           MaxSelectedIndex="{Binding Path=MaxSelectedIndex}">
            <ComboBoxItem>Item 1</ComboBoxItem>
            <ComboBoxItem>Item 2</ComboBoxItem>
            <ComboBoxItem>Item 3</ComboBoxItem>
            <ComboBoxItem>Item 4</ComboBoxItem>
            <ComboBoxItem>Item 5</ComboBoxItem>
        </wpfProj:ExtendedCombobBox>
    </StackPanel>
