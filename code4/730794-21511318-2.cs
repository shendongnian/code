        // Gets the ChartArea that the mouse points
        private ChartArea mouseinChartArea(Chart source, Point e)
        {
            double relativeX = (double)e.X * 100 / source.Width;
            double relativeY = (double)e.Y * 100 / source.Height;
            foreach (ChartArea ca in source.ChartAreas)
            {
                if (relativeX > ca.Position.X && relativeX < ca.Position.Right &&
                    relativeY > ca.Position.Y && relativeY < ca.Position.Bottom)
                    return ca;
            }
            return null;
        }
        
        // for my purpose, returns an axis. But you can return anything
        private Axis findAxisforZooming(Chart source, Point e)
        {
            ChartArea currentArea = mouseinChartArea(source, new Point(e.X, e.Y)); // Check if inside 
            if (currentArea == null)
                return null;
            double axisXfontSize = currentArea.AxisX.LabelAutoFitMinFontSize + ((double)source.Width / SystemInformation.PrimaryMonitorSize.Width)
                * (currentArea.AxisX.LabelAutoFitMaxFontSize - currentArea.AxisX.LabelAutoFitMinFontSize);
            double axisYfontSize = currentArea.AxisY.LabelAutoFitMinFontSize + ((double)source.Height / SystemInformation.PrimaryMonitorSize.Height)
                * (currentArea.AxisY.LabelAutoFitMaxFontSize - currentArea.AxisY.LabelAutoFitMinFontSize);
            double axisYfontHeightSize = (axisYfontSize - currentArea.AxisY.LabelStyle.Font.Size) + currentArea.AxisY.LabelStyle.Font.Height;
            Graphics g = this.CreateGraphics();
            if (currentArea.AxisX.LabelStyle.Font.Unit == GraphicsUnit.Point)
                axisXfontSize = axisXfontSize * g.DpiX / 72;
            if (currentArea.AxisY.LabelStyle.Font.Unit == GraphicsUnit.Point)
                axisYfontHeightSize = axisYfontHeightSize * g.DpiX / 72;
            g.Dispose();
            // Replacing the SystemInformation.PrimaryMonitorSize with the source.Width / Height will give the accurate TickMarks size.
            // But it doens't count for the gab between the tickMarks and the axis lables (so by replacing, it give a good proximity with the gab)
            int axisYTickMarks = (int)Math.Round(currentArea.AxisY.MajorTickMark.Size / 100 * SystemInformation.PrimaryMonitorSize.Width); // source.Width;
            int axisXTickMarks = (int)Math.Round(currentArea.AxisX.MajorTickMark.Size / 100 * SystemInformation.PrimaryMonitorSize.Height); // source.Height;
            int leftInnerPlot = (int)Math.Round(currentArea.Position.X / 100 * source.Width +
                currentArea.InnerPlotPosition.X / 100 * currentArea.Position.Width / 100 * source.Width);
            int rightInnerPlot = (int)Math.Round(currentArea.Position.X / 100 * this.chart1.Width +
                currentArea.InnerPlotPosition.Right / 100 * currentArea.Position.Width / 100 * source.Width);
            int topInnerPlot = (int)Math.Round(currentArea.Position.Y / 100 * this.chart1.Height +
                currentArea.InnerPlotPosition.Y / 100 * currentArea.Position.Height / 100 * source.Height);
            int bottomInnerPlot = (int)Math.Round(currentArea.Position.Y / 100 * source.Height +
                currentArea.InnerPlotPosition.Bottom / 100 * currentArea.Position.Height / 100 * source.Height);
            // Now you got the boundaries of every important ChartElement.
            // Only left to check if the mouse is within your desire ChartElement,
            // like the following:    
            bottomInnerPlot += axisXTickMarks + (int)Math.Round(axisXfontSize); // Include AxisX
            if (e.X > leftInnerPlot && e.X < rightInnerPlot &&
                e.Y > topInnerPlot && e.Y < bottomInnerPlot) // return AxisX if inside the InnerPlot area or on AxisX
                return currentArea.AxisX;
            else if (e.X > (leftInnerPlot - axisYTickMarks - (int)Math.Round(axisYfontHeightSize)) && e.X < rightInnerPlot &&
                     e.Y > topInnerPlot && e.Y < bottomInnerPlot) // return AxisY if on AxisY only
                return currentArea.AxisY;
            return null;
        }
