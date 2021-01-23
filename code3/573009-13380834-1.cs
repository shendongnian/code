    using System;
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Research.DynamicDataDisplay.DataSources;
    using Microsoft.Research.DynamicDataDisplay.PointMarkers;
    using Microsoft.Research.DynamicDataDisplay.Common;
    namespace Microsoft.Research.DynamicDataDisplay.Charts {
    public class FilteredMarkerPointsGraph : MarkerPointsGraph {
        public FilteredMarkerPointsGraph()
            : base() {
            ;
        }
        public FilteredMarkerPointsGraph(IPointDataSource dataSource)
            : base(dataSource) {
            ;
        }
        protected override void OnRenderCore(DrawingContext dc, RenderState state) {
            // base.OnRenderCore
            if (DataSource == null) return;
            if (Marker == null) return;
            var left = Viewport.Visible.Location.X;
            var right = Viewport.Visible.Location.X + Viewport.Visible.Size.Width;
            var top = Viewport.Visible.Location.Y;
            var bottom = Viewport.Visible.Location.Y + Viewport.Visible.Size.Height;
            var transform = Plotter2D.Viewport.Transform;
            
            DataRect bounds = DataRect.Empty;
            using (IPointEnumerator enumerator = DataSource.GetEnumerator(GetContext())) {
                Point point = new Point();
                while (enumerator.MoveNext()) {
                    enumerator.GetCurrent(ref point);                                       
                    if (point.X >= left && point.X <= right && point.Y >= top && point.Y <= bottom)
                    {
                        enumerator.ApplyMappings(Marker);
 
                        Point screenPoint = point.DataToScreen(transform);
 
                        bounds = DataRect.Union(bounds, point);
                        Marker.Render(dc, screenPoint);
                    }
                }
            }
            Viewport2D.SetContentBounds(this, bounds);
        }
    }
