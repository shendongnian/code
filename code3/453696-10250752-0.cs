    <Expander x:Name="expander" ExpandDirection="Right" OpacityMask="#6C806969" Background="#FF807171">
        ... Content ...
        <Expander.Style>
            <Style TargetType="{x:Type Expander}">
                <Setter Property="LayoutTransform">
                    <Setter.Value>
                        <ScaleTransform ScaleX="1" />
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsExpanded" Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation From="0" To="1.2" Duration="0:0:0.35" AutoReverse="False"
                                                     Storyboard.TargetProperty="LayoutTransform.(ScaleTransform.ScaleX)" />
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                    </Trigger>       
                </Style.Triggers>
            </Style>
        </Expander.Style>
    </Expander>
