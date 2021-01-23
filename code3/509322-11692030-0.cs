    <UserControl.Resources>
        <Storyboard Name="FadeOutStoryboard" x:Key="FadeOutStoryboard" >
            <DoubleAnimation Storyboard.TargetName="userControlStatusPanel" 
                             Storyboard.TargetProperty="Opacity" 
                             From="1" To="0" Duration="0:0:3" RepeatBehavior="Forever"  />
        </Storyboard>
    </UserControl.Resources>
			Storyboard sb = (Storyboard)UserControl.FindResource("FadeOutStoryboard");
			LinearGradientBrush myBrush = new LinearGradientBrush();
			myBrush.EndPoint = new Point(0, 0);
			myBrush.StartPoint = new Point(1, 1);
			if (runProgress.Percent == 100)
			{
				myBrush.GradientStops.Add(new GradientStop(Colors.Green, 0));
				myBrush.GradientStops.Add(new GradientStop(Colors.Silver, 1));
				sb.Stop();
			}
			else (runProgress.Percent <= 100)
			{
				myBrush.GradientStops.Add(new GradientStop(Colors.Red, 0));
				myBrush.GradientStops.Add(new GradientStop(Colors.Silver, 1));
				sb.Begin();
			}
			UserControl.borderMain.Background = myBrush;
		}
