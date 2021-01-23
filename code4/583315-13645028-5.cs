    <DataTemplate>
        <TextBox Text="{Binding Number}">
            <Interactivity:Interaction.Triggers>
                <Interactivity:EventTrigger EventName="Loaded">
                    <TriggerActions:TakeFocusAction />
                </Interactivity:EventTrigger>
            </Interactivity:Interaction.Triggers>
        </TextBox>
    </DataTemplate>
