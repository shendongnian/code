    <TabControl Name="tabControl1" TabStripPlacement="Bottom" Background="Transparent" Margin="-2,32,15,6" Grid.RowSpan="4" BorderThickness="0">
            <TabItem Name="tabItem1" Margin="0,0,0,1" Panel.ZIndex="4">
                <TabItem.Header>
                    <TextBlock>
                Main</TextBlock>
                </TabItem.Header>
                <Border CornerRadius="40,40,0,0" Background="Orange" Grid.RowSpan="4" Panel.ZIndex="-3" ></Border>
            </TabItem>
            <TabItem Name="tabItem2" Panel.ZIndex="5">
                <TabItem.Header>
                    <TextBlock Height="13" Width="91">
                Internet Explorer</TextBlock>
                </TabItem.Header>
                <Border CornerRadius="40,40,0,0" Background="OrangeRed" Grid.RowSpan="4" Name="border1" Panel.ZIndex="5"></Border>
            </TabItem>
            <TabItem Name="tabItem3" Panel.ZIndex="0">
                <TabItem.Header>
                    <TextBlock>
               Firefox</TextBlock>
                </TabItem.Header>
                <Border CornerRadius="40,40,0,0" Background="Red" Grid.RowSpan="4" Panel.ZIndex="-1"></Border>
            </TabItem>
            <TabItem Name="tabItem4" Panel.ZIndex="-2">
                <TabItem.Header>
                    <TextBlock>
               Chrome</TextBlock>
                </TabItem.Header>
                <Border CornerRadius="40,40,0,0" Background="Yellow" Grid.RowSpan="4" Panel.ZIndex="1"></Border>
            </TabItem>
            <TabItem Name="tabItem5" Panel.ZIndex="-4">
                <TabItem.Header>
                    <TextBlock>
               Opera</TextBlock>
                </TabItem.Header>
                <Border CornerRadius="40,40,0,0" Background="DarkRed" Grid.RowSpan="4" Panel.ZIndex="3"></Border>
            </TabItem>
        </TabControl>
