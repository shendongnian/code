            private void AdjustPanels(object sender, EventArgs e)
            {
            double desiredAspectRatio = 1;
            // I am using the form itself as a reference to the size and aspect ration of the application.
            // you can, of course, use any other control instead (e.g. a panel where you stuff all the other panels
            int width = this.Width;
            int height = this.Height;
            double formAspectRatio = (double)width / (double)height;
            int marginLeft=0, marginRight=0, marginTop=0, marginBottom=0;
            
            if (desiredAspectRatio > formAspectRatio)
            {
                // high aspect ratios mean a wider picture -> the picture we want is wider than what it currently is
                // so we will need a margin on top and bottom
                marginLeft = 0; marginRight = 0;
                marginTop = (int)((height - desiredAspectRatio * width) / 2);
                marginBottom = (int)((height - desiredAspectRatio * width) / 2);
            }
            else
            {
                marginTop = 0; marginBottom = 0;
                marginLeft = (int)((width - desiredAspectRatio*height)/2);
                marginRight = (int)((width - desiredAspectRatio * height) / 2);
            }
            pnlTop.Height = marginTop;
            pnlBottom.Height = marginBottom;
            pnlLeft.Width = marginLeft;
            pnlRight.Width = marginRight;
        }
