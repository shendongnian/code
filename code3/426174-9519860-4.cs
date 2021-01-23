       public static void ForceUIToUpdate()
       {
           DispatcherFrame frame = new DispatcherFrame();
           Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Render, new     DispatcherOperationCallback(delegate(object parameter)
           {
               frame.Continue = false;
               return null;
           }), null);
           Dispatcher.PushFrame(frame);
       }
