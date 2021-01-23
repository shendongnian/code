     new WaitCallback
     (
        (_) =>
        {
          dynamic _serviceobject= InitializeCRMService();
         //Here raise the event
         SomeEventArgs e = new SomeEventArgs(_serviceObject);
         OnWorkerFinished(this, e);
        }
     )
