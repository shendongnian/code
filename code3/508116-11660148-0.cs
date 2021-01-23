    <Rectangle Fill="White"
               Stroke="Black"
               Width="200"
               Height="100">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="MouseEnter">
                <cmd:EventToCommand Command="{Binding TestCommand,
                                              Mode=OneWay}"
                   CommandParameter="{Binding Text,
                                      ElementName=MyTextBox,
                                      Mode=OneWay}"
                   MustToggleIsEnabledValue="True" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </Rectangle>
