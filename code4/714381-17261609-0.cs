	<Window x:Class="WpfApplication3.MainWindow"
			xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			Title="MainWindow" Height="350" Width="525">
		<Grid>
			<Grid.Resources>
				<Style TargetType="Button">
					<Style.Triggers>
						<MultiTrigger>
							<MultiTrigger.Conditions>
								<Condition Property="Content" Value="XYZ" />
							</MultiTrigger.Conditions>
							<MultiTrigger.EnterActions>
								<BeginStoryboard>
									<Storyboard>
										<StringAnimationUsingKeyFrames Storyboard.TargetProperty="Content">
											<DiscreteStringKeyFrame KeyTime="00:00:00" Value="ABC" />
										</StringAnimationUsingKeyFrames>
									</Storyboard>
								</BeginStoryboard>
							</MultiTrigger.EnterActions>
						</MultiTrigger>
						<MultiTrigger>
							<MultiTrigger.Conditions>
								<Condition Property="Content" Value="ABC" />
							</MultiTrigger.Conditions>
							<MultiTrigger.EnterActions>
								<BeginStoryboard>
									<Storyboard >
										<StringAnimationUsingKeyFrames  Storyboard.TargetProperty="Content">
											<DiscreteStringKeyFrame KeyTime="00:00:00" Value="XYZ" />
										</StringAnimationUsingKeyFrames>
									</Storyboard>
								</BeginStoryboard>
							</MultiTrigger.EnterActions>
						</MultiTrigger>
					</Style.Triggers>
				</Style>
			</Grid.Resources>
			<Button x:Name="btn" Tag="1" Content="XYZ" />
		</Grid>
	</Window>
