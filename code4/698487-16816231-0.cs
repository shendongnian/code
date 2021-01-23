	<Storyboard x:Key="TestBlinkStoryboard" AutoReverse="True" RepeatBehavior="Forever">
			<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="textBlock">
				<EasingColorKeyFrame KeyTime="0" Value="Black"/>
				<EasingColorKeyFrame KeyTime="0:0:0.5" Value="#FFE91414">
					<EasingColorKeyFrame.EasingFunction>
						<BounceEase EasingMode="EaseInOut"/>
					</EasingColorKeyFrame.EasingFunction>
				</EasingColorKeyFrame>
			</ColorAnimationUsingKeyFrames>
		</Storyboard>
