        //Reset graph transform
        public void resetTransform(Boolean useSlider = false)
        {
            double yscale = plot.Height / view.YMAX; //YMAX is maximum plot value received
            double xscale = plot.Width / view.XMAX; //XMAX is total ammount of plotted points
            Matrix m = new Matrix(1, 0, 0, 1, 0, 0);
            if (useSlider)
            {
                double maxVal = zoomBar.ActualWidth - outPoint.Width;
                double outP = Canvas.GetLeft(outPoint); //points position relative to the scrollbar
                double inP = Canvas.GetLeft(inPoint);
                double delta = (outP-inP);
                double factor = (maxVal/delta) * xscale;
                anchorOut = (outP / maxVal) * view.XMAX; //Define anchorpoint coordinates
                anchorIn = (inP / maxVal) * view.XMAX;
                double center = (anchorOut +anchorIn)/2; //Define centerpoint
                m.Translate(-anchorIn, 0); //Move graph to inpoint
                m.ScaleAt(factor, -yscale,0,0); //scale around the inpoint, with a factor so that outpoint is plot.Height(=600px) further away
                m.Translate(0, plot.Height); //to compensate the flipped graph, move it back down
            }
                scale = new ScaleTransform(m.M11, m.M22, 0, 0); //save scale factors in a scaletransform for reference
                signals.scaleSignalStrokes(scale); //Scale the plotlines to compensate for canvas scaling
                MatrixTransform matrixTrans = new MatrixTransform(m); //Create matrixtransform
                plot.RenderTransform = matrixTrans; //Apply to canvas
        }
