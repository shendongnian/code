        protected void OnWindowSizeChanged (object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize.Height != 0)
            {
                if (e.HeightChanged)
                {
                    double heightChange = e.NewSize.Height - e.PreviousSize.Height;
                    if (lbxUninspectedPrints.Height + heightChange > 0)
                    {
                        lbxUninspectedPrints.Height = lbxUninspectedPrints.Height + heightChange;
                    }
                }
            }
            prevHeight = e.PreviousSize.Height;
        }
