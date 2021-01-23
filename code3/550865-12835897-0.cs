    <ComboBox Height="23" ItemsSource="{Binding BusRateList}" SelectedItem="{Binding SelectedBusRateItem,Mode=TwoWay}" SelectedIndex="2"  Name="comboBox2"  >
      <i:Interaction.Triggers>
                        <i:EventTrigger EventName="SelectionChanged">
                        <Command:EventToCommand Command="{Binding SelectionChangedCommand}" PassEventArgsToCommand="True" />
                    </i:EventTrigger>
                    </i:Interaction.Triggers>
    </ComboBox>
