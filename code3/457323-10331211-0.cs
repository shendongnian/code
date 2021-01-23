     using (new HwndSource(new HwndSourceParameters())
                       {
                           RootVisual =
                               (VisualTreeHelper.GetParent(objToBeRendered) == null
                                    ? objToBeRendered
                                    : null)
                       })
            {
                // Flush the dispatcher queue
                objToBeRendered.Dispatcher.Invoke(DispatcherPriority.SystemIdle, new Action(() => { }));
                var renderBitmap = new RenderTargetBitmap(requiredWidth, requiredHeight,
                                                          96d*requiredWidth/actualWidth, 96d*requiredHeight/actualHeight,
                                                          PixelFormats.Default);
                renderBitmap.Render(objToBeRendered);
                renderBitmap.Freeze();                
                return renderBitmap;
            }
