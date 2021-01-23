    <TabControl>
      <i:Interaction.Triggers>
        <i:EventTrigger EventName="SelectionChanged">
          <cmd:EventToCommand Command="{Binding TabSelectionChangedCommand}"
                              PassEventArgsToCommand="True" />
        </i:EventTrigger>
      </i:Interaction.Triggers>
      <TabItem>...</TabItem>
      <TabItem>...</TabItem>
    </TabControl>
