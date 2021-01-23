        private void DrawLine(List<int> p_values, SolidColorBrush cor)
        {            
            double stepHorizontal = cnvChart.ActualWidth / ((this.MaxHorizontal - this.MinHorizontal) + 1);
            double stepVertical = cnvChart.ActualHeight / ((this.MaxVertical - this.MinVertical) + 1);
            
            List<Point> pts = new List<Point>();
            
            for (int i = 0; i < p_values.Count; i++)
            {
                int val = p_values[i];
                double x = (stepHorizontal * i);
                double y = cnvChart.ActualHeight - ((val - this.MinVertical) * stepVertical);
                pts.Add(new Point(x,y));                       
            }
            FastCanvas.ScopeLine newLine;
            newLine.lineBrush = cor;
            newLine.linePoints = pts;
            cnvChart.Lines.Add(newLine);            
        }
