    <TabControl AlternationCount="{Binding Path=Items.Count,RelativeSource={RelativeSource Self}}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex"
                                Value="0"> <!-- First item -->
                        <Setter Property="FontWeight"
                                Value="Bold"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TabControl.ItemContainerStyle>
        <TabItem Header="First"/>
        <TabItem Header="Second"/>
        <TabItem Header="Third"/>
        <TabItem Header="Fourth"/>
    </TabControl>
