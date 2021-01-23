    public class LoadingPanel
        {
            private VisualWrapper.VisualWrapper visualWrapper;
    
            public LoadingPanel(VisualWrapper.VisualWrapper _visualWrapper)
            {
                visualWrapper = _visualWrapper;
            }
    
            public VisualWrapper.VisualWrapper VisualWrapper
            {
                get { return visualWrapper; }
                set { visualWrapper = value; }
            }
    
            #region WaitDailog
    
            public HostVisual CreateMediaElementOnWorkerThread()
            {
                // Create the HostVisual that will "contain" the VisualTarget
                // on the worker thread.
                HostVisual hostVisual = new HostVisual();
    
                // Spin up a worker thread, and pass it the HostVisual that it
                // should be part of.
    
                Thread thread = new Thread(new ParameterizedThreadStart(MediaWorkerThread));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(new object[] { hostVisual, visualWrapper });
    
                // Wait for the worker thread to spin up and create the VisualTarget.
                s_event.WaitOne();
    
                return hostVisual;
            }
    
            private FrameworkElement CreateMediaElement(RMS.Common.Controls.VisualWrapper.VisualWrapper visualWrapper)
            {
                BitmapImage bi = new BitmapImage(new Uri(--YOURIMAGEPATH--));//Image path goes here
                Image image = new Image();
                image.Source = bi;
                image.Height = 150;
                image.Width = 150;
                //image.Margin = new Thickness(-150, -150, -150, -150);
    
                ImageBehavior.SetAnimatedSource(image, bi);
    
                BrushConverter conv = new BrushConverter();
                //SolidColorBrush brush = conv.ConvertFromString("#6C8BBA") as SolidColorBrush;
                Border border = new Border();
                border.Background = Brushes.Transparent;
                //border.BorderBrush = brush;
                //border.BorderThickness = new Thickness(3);
                //border.Margin = new Thickness(-85, -140, 0, 0);
    
                border.Child = image;
    
                return border;
            }
    
            private void MediaWorkerThread(object arg)
            {
                // Create the VisualTargetPresentationSource and then signal the
                // calling thread, so that it can continue without waiting for us.
                HostVisual hostVisual = (HostVisual)((object[])arg)[0];
                RMS.Common.Controls.VisualWrapper.VisualWrapper visualWrapper = (RMS.Common.Controls.VisualWrapper.VisualWrapper)((object[])arg)[1];
    
                VisualTargetPresentationSource visualTargetPS = new VisualTargetPresentationSource(hostVisual);
                s_event.Set();
    
                // Create a MediaElement and use it as the root visual for the
                // VisualTarget.
                visualTargetPS.RootVisual = CreateMediaElement(visualWrapper);
    
                // Run a dispatcher for this worker thread.  This is the central
                // processing loop for WPF.
                System.Windows.Threading.Dispatcher.Run();
            }
    
            private static AutoResetEvent s_event = new AutoResetEvent(false);
    
            public bool ShowWaitDialog()
            {
                if (visualWrapper != null)
                {
                    if (visualWrapper.Child == null)
                    {
                        visualWrapper.Child = CreateMediaElementOnWorkerThread();
                    }
                }
    
                return true;
            }
    
            public bool DisposeWaitDialog()
            {
                if (visualWrapper != null)
                {
                    visualWrapper.Child = null;
                }
    
                return true;
            }
    
            #endregion
    
        }
