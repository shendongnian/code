    <ComboBox x:Name="ConfigurationComboBox" VerticalContentAlignment="Center"  ToolTip="saved configuration" SelectionChanged="ConfigurationComboBox_SelectionChanged">
            <ComboBox.ItemTemplate>
               <DataTemplate >
                   <StackPanel>
                      <TextBlock Text="{Binding}" ToolTip="{Binding Path}"></TextBlock>
                   </StackPanel>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
