            var c = new PointMarker();
            c.Template = pointMarkerTemplate;
            c.ApplyTemplate();
            // DispatcherUtil is just a proxy around Dispatcher.BeginInvoke
            DispatcherUtil.Instance.BeginInvoke(() =>
            {
                c.MeasureArrange();
                c.Width = c.DesiredSize.Width;
                c.Height = c.DesiredSize.Height;
                series._pointMarkerCache = c.RenderToBitmap();
                series.OnInvalidateParentSurface();
            });
