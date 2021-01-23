    private void imgSanta_ManipulationStarted_1(object sender, ManipulationStartedRoutedEventArgs e)
            {
                txtFeedback.Text = "Manipulation started";
            }
    
            private void imgSanta_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
            {                
                var newTop = imgSanta.Margin.Top + e.Delta.Translation.Y;
                var newLeft = imgSanta.Margin.Left + e.Delta.Translation.X;
                imgSanta.Margin = new Thickness(newLeft, newTop, 0, 0);
            } 
