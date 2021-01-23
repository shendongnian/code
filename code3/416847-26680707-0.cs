            var textBlock = new TextBlock {Text = "abc abd adfdfd", TextWrapping = TextWrapping.Wrap};
            // auto sized
            textBlock.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            Debug.WriteLine(textBlock.ActualWidth); // prints 80.323333333333
            Debug.WriteLine(textBlock.ActualHeight);// prints 15.96
            // constrain the width to 16
            textBlock.Measure(new Size(16, Double.PositiveInfinity));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            Debug.WriteLine(textBlock.ActualWidth); // prints 14.58
            Debug.WriteLine(textBlock.ActualHeight);// prints 111.72
