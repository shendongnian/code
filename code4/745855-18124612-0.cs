    <MultiDataTrigger>
        <MultiDataTrigger.Conditions>
            <Condition Binding="{Binding RelativeSource={RelativeSource self}, Path=IsMouseOver}" Value="True" />
            <Condition Binding="{Binding RotorLobes}" Value="1" />
        </MultiDataTrigger.Conditions>
        <MultiDataTrigger.EnterActions>
             <BeginStoryboard Storyboard="{StaticResource ShakeStatorMinorRadiusEdit}"/>
        </MultiDataTrigger.EnterActions>
    </MultiDataTrigger>
