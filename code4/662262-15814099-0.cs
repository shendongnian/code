    Graphics g = e.Graphics;
    
            base.OnPaint(e);
            //// Fill the background
            //SetControlSizes();
    
            // Paint the outer rounded rectangle
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath outerPath = GeneralUtilities.RoundedRectangle(mLabelRect, 1, 0))
            {
                using (LinearGradientBrush outerBrush = new LinearGradientBrush(mLabelRect,
                       mGradientTop, mGradientBottom, LinearGradientMode.Vertical))
                {
                    g.FillPath(outerBrush, outerPath);
                }
                using (Pen outlinePen = new Pen(mGradientTop, mRectOutlineWidth))
                {
                    outlinePen.Alignment = PenAlignment.Inset;
                    g.DrawPath(outlinePen, outerPath);
                }
            }
    
            //// Paint the gel highlight
            using (GraphicsPath innerPath = GeneralUtilities.RoundedRectangle(mHighlightRect, mRectCornerRadius, mHighlightRectOffset))
            {
                using (LinearGradientBrush innerBrush = new LinearGradientBrush(mHighlightRect,
                       Color.FromArgb(mHighlightAlphaTop, Color.White),
                       Color.FromArgb(mHighlightAlphaBottom, Color.White), LinearGradientMode.Vertical))
                {
                    g.FillPath(innerBrush, innerPath);
                }
            }
            // Paint the text
            TextRenderer.DrawText(g, Text, Font, mLabelRect, Color.White, Color.Transparent,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
