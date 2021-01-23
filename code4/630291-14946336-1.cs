    Literal2.Text = FusionCharts.RenderChart(
                "FusionChartsXT/Column3D.swf", // Path to chart's SWF
                "", // Page which returns chart data. Leave blank when using Data String.
                xmlStr.ToString(), // String containing the chart data. Leave blank when using Data URL.
                "annual_revenue",   // Unique chart ID
                "640", "340",       // Width & Height of chart
                false,              // Disable Debug Mode
                true);
