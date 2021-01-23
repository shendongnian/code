    private double calcCursorGraphX(int clientX)
    {
        var xAxis = _chart.ChartAreas[CHART_INDEX].AxisX;
        int xRight = (int) xAxis.ValueToPixelPosition(xAxis.Maximum) - 1;
        int xLeft = (int) xAxis.ValueToPixelPosition(xAxis.Minimum);
        if (clientX > xRight)
        {
            return xAxis.Maximum;
        }
        else if (clientX < xLeft)
        {
            return xAxis.Minimum;
        }
        else
        {
            return xAxis.PixelPositionToValue(clientX);
        }
    }
