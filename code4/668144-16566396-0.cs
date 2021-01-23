    private double GetHeaderFooterHeight(string headerFooter)
            {
    
                var section = (Section)XamlReader.Parse(headerFooter, _pd.ParserContext);
                var flowDoc = new FlowDocument();
                flowDoc.Blocks.Add(section);
    
                var richtextbox = new RichTextBox { Width = double.MaxValue, Document = flowDoc };
                var viewbox = new Viewbox { Child = richtextbox };
    
                viewbox.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                viewbox.Arrange(new Rect(viewbox.DesiredSize));
    
                var size = new Size() { Height = viewbox.ActualHeight, Width = viewbox.ActualWidth };
    
                return size.Height;
            }
