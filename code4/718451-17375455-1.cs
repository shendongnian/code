        <ListBox ItemsSource="{Binding Images}"
                 x:Name="listBox"
                 ScrollViewer.HorizontalScrollBarVisibility="Disabled"
                 ScrollViewer.VerticalScrollBarVisibility="Disabled"
                 ScrollViewer.ManipulationMode="Control"
                 Loaded="listBox_Loaded_1" 
				 
                      >
            <ListBox.Resources>
                <Storyboard x:Name="ScrollStoryboard">
                    <DoubleAnimation x:Name="AnimationH" Duration="0:0:0.5">
                        <DoubleAnimation.EasingFunction>
                            <CubicEase EasingMode="EaseInOut"/>
                        </DoubleAnimation.EasingFunction>
                    </DoubleAnimation>
                    <DoubleAnimation x:Name="AnimationV" Duration="0:0:0.5">
                        <DoubleAnimation.EasingFunction>
                            <CubicEase EasingMode="EaseInOut"/>
                        </DoubleAnimation.EasingFunction>
                    </DoubleAnimation>
                </Storyboard>
            </ListBox.Resources>
            <ListBox.ItemContainerStyle>
                <StaticResource ResourceKey="ListBoxItemPivotStyle"/>
            </ListBox.ItemContainerStyle>
        </ListBox>
        <Rectangle Fill="Transparent"
                   x:Name="TouchRectangle"
                   ManipulationCompleted="Rectangle_ManipulationCompleted_1"
                   ManipulationDelta="Rectangle_ManipulationDelta_1"
                   ManipulationStarted="Rectangle_ManipulationStarted_1"/>
