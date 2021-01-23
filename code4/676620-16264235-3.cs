    <Style x:Key="NotificationStyle" TargetType="{x:Type Border}">
        <Style.Triggers>
            <Trigger Property="Visibility" Value="Visible">
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" BeginTime="0:0:0" From="0.0" To="1.0" Duration="0:0:1.0" />
                            <DoubleAnimation Storyboard.TargetProperty="Opacity" BeginTime="0:0:5" From="1.0" To="0.0" Duration="0:0:1.0" />
                        </Storyboard>
                    </BeginStoryboard>
               </Trigger.EnterActions>
           </Trigger>
       </Style.Triggers>
    </Style>
