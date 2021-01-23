    protected void ChartExample_DataBound(object sender, EventArgs e)
    {
        // If there is no data in the series, show a text annotation
        if(ChartExample.Series[0].Points.Count == 0)
        {
            System.Web.UI.DataVisualization.Charting.TextAnnotation annotation = 
                new System.Web.UI.DataVisualization.Charting.TextAnnotation();
            annotation.Text = "No data for this period";
            annotation.X = 5;
            annotation.Y = 5;
            annotation.Font = new System.Drawing.Font("Arial", 12);
            annotation.ForeColor = System.Drawing.Color.Red;
            ChartExample.Annotations.Add(annotation);
        }
    }
