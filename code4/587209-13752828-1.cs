     <Button>
    <i:Interaction.Triggers>
        <i:EventTrigger EventName="MouseDoubleClick" >
             <cmd:EventToCommand Command="{Binding MouseDoubleClickCommand}"
                 PassEventArgsToCommand="True" />
        </i:EventTrigger>
    </i:Interaction.Triggers>
