    	<Button Content="OK" Height="46" Width="98">
			<Button.Triggers>
				<EventTrigger RoutedEvent="UIElement.MouseEnter">
					<BeginStoryboard>
						<Storyboard>
							<DoubleAnimation Storyboard.TargetProperty="Opacity"
                             From="1.0" To="0.5" Duration="0:0:0.5"/>
						</Storyboard>
					</BeginStoryboard>
				</EventTrigger>
				<EventTrigger RoutedEvent="UIElement.MouseLeave">
					<BeginStoryboard>
						<Storyboard>
							<DoubleAnimation Storyboard.TargetProperty="Opacity"
                             From="0.5" To="1.0" Duration="0:0:0.5"/>
						</Storyboard>
					</BeginStoryboard>
				</EventTrigger>			
			</Button.Triggers>
		</Button>
