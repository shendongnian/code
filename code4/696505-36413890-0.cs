    // For access to the Legend class
    using Microsoft.Research.DynamicDataDisplay.Charts;
    
    ... snip ...
    LineGraph lineGraph = new LineGraph(dataSource);
    lineGraph.LinePen = new Pen(Brushed.Green, 1.0);
    Legend.SetDescription(lineGraph, "The line label");
    plotter.Children.Add(lineGraph);
    ... snip ...
