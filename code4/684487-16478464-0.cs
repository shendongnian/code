       /// <summary>
        /// Gets a List of all Charts on this Slide
        /// </summary>
        /// <param name="slidepart">The SlidePart.</param>
        /// <returns>A List of all Charts on this Slide</returns>
        private List<PPChart> GetChartsfromSlide(SlidePart slidepart)
        {
            var chartList = new List<PPChart>();
            if (slidepart.ChartParts.Any())
            {
                foreach (var chart in slidepart.ChartParts)
                {
                    //// get the ID of the Chart-Part
                    var id = slidepart.GetIdOfPart(chart);
                    //// Get a list of all Shapes(Graphicframes) which contain Charts
                    var gshapes = from shapeDesc in slidepart.Slide.Descendants<GraphicFrame>() select shapeDesc;
                    var tempgshapes = gshapes.ToList();
                    //// Select all possible Shapes which have Graphics
                    var thisShape = from Gshape in tempgshapes where this.HasThisChart(id, Gshape) select Gshape;
                    var result = thisShape.ToList();
                    this.logger.Debug("Found Chart with ID:{0} Name:{1}", result[0].NonVisualGraphicFrameProperties.NonVisualDrawingProperties.Id, result[0].NonVisualGraphicFrameProperties.NonVisualDrawingProperties.Name);
                    var ppchart = new PPChart(result[0].NonVisualGraphicFrameProperties.NonVisualDrawingProperties.Id);
                    ppchart.ShapeName = result[0].NonVisualGraphicFrameProperties.NonVisualDrawingProperties.Name;
                    chartList.Add(ppchart);
                }
            }
            return chartList;
        }
        /// <summary>
        /// Determines whether the Slider has this Chart or not.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="gframe">The gframe.</param>
        /// <returns>
        ///   <c>true</c> if the Slide has the chart; otherwise, <c>false</c>.
        /// </returns>
        private bool HasThisChart(string id, GraphicFrame gframe)
        {
            var returnValue = false;
            if (!(gframe == null) && this.HasGraphic(gframe))
            {
                if (!(gframe.Graphic.GraphicData == null))
                {
                    var graphicData = gframe.Graphic.GraphicData;
                    var drawChartsRef = graphicData.Descendants<DrawCharts.ChartReference>();
                    if (!(drawChartsRef == null))
                    {
                        foreach (var drawChart in drawChartsRef)
                        {
                            if (drawChart.Id == id)
                            {
                                returnValue = true;
                            }
                        }
                    }
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Determines whether the specified GraphicFrame has a graphic (A graphic is a chart!).
        /// </summary>
        /// <param name="gframe">The gframe.</param>
        /// <returns>
        ///   <c>true</c> if the specified gframe has a graphic; otherwise, <c>false</c>.
        /// </returns>
        private bool HasGraphic(GraphicFrame gframe)
        {
            var returnValue = false;
            if (!(gframe == null))
            {
                var graphicDescendants = gframe.Descendants<Draw.Graphic>();
                if (graphicDescendants.Count() > 0)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
