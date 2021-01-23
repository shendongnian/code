		element.Visibility = Visibility.Visible;
		element.InvalidateArrange();
		element.UpdateLayout();
		double elementHeight = element.DesiredSize.Height;
		DoubleAnimation animation = new DoubleAnimation(0, elementHeight, TimeSpan.FromMilliseconds(animMilisec));
		element.BeginAnimation(Rectangle.HeightProperty, animation);
