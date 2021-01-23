    <Style TargetType="c:Cart">
		<Setter Property="Margin" Value="{x:Static s:S+Cart.Hidden}" />
		<Style.Triggers>
			<Trigger Property="Layout" Value="Visible">
				<Trigger.EnterActions>
					<RemoveStoryboard BeginStoryboardName="CartCollapsed" />
					<RemoveStoryboard BeginStoryboardName="CartHidden" />
					<BeginStoryboard Name="CartVisible">
						<Storyboard>
							<ThicknessAnimation Storyboard.TargetProperty="Margin"
										Duration="0:0:0.5"
										To="{x:Static s:S+Cart.Visible}" />
						</Storyboard>
					</BeginStoryboard>
				</Trigger.EnterActions>
			</Trigger>
			<Trigger Property="Layout" Value="Collapsed">
				<Trigger.EnterActions>
					<RemoveStoryboard BeginStoryboardName="CartVisible" />
					<RemoveStoryboard BeginStoryboardName="CartHidden" />
					<BeginStoryboard Name="CartCollapsed">
						<Storyboard>
							<ThicknessAnimation Storyboard.TargetProperty="Margin"
										Duration="0:0:0.5"
										To="{x:Static s:S+Cart.Collapsed}" />
						</Storyboard>
					</BeginStoryboard>
				</Trigger.EnterActions>
			</Trigger>
			<Trigger Property="Layout" Value="Hidden">
				<Trigger.EnterActions>
					<RemoveStoryboard BeginStoryboardName="CartVisible" />
					<RemoveStoryboard BeginStoryboardName="CartCollapsed" />
					<BeginStoryboard Name="CartHidden">
						<Storyboard>
							<ThicknessAnimation Storyboard.TargetProperty="Margin"
										Duration="0:0:0.5"
										To="{x:Static s:S+Cart.Hidden}" />
						</Storyboard>
					</BeginStoryboard>
				</Trigger.EnterActions>
			</Trigger>
		</Style.Triggers>
