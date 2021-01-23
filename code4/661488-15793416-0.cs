    public ActionResult Cars(KendoDataSourceRequest request)
       {
          controller_action.Stop();
          System.Diagnostics.Debug.WriteLine(controller_action.Elapsed);
          controller_action.Restart();
       }
