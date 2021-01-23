        private void GestureListener_Tap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
        {
            Canvas cv = sender as Canvas;
            //!!! You need to change the following search for the webbrowser to your own    xaml structure.
            // It uses "LinqToVisualTree" to find the element! Add it to your document!
            WebBrowser wb = cv.Ancestors<Grid>().First().ElementsBeforeSelf<WebBrowser>().First() as WebBrowser;
            var gesture = e.GetPosition(cv);
            var gx = gesture.X;
            var gy = gesture.Y;
            tapBrowser(wb, gx, gy);
        }
        private static void tapBrowser(WebBrowser wb, double x, double y)
        {
            GeneralTransform gt = wb.TransformToVisual(Application.Current.RootVisual as UIElement);
            Point offset = gt.Transform(new Point(0, 0));
            double rx = (x / 1.3499);
            double ry = (y / 1.3499);
            int ix = (int)rx;
            int iy = (int)ry;
            wb.InvokeScript("simulateClick", ix.ToString(), iy.ToString());
        }
