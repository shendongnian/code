     Deployment.Current.Dispatcher.BeginInvoke(() =>
      {
        try
        {
            foreach (TextBlock txb in StackP.Children){
              txb.Text = "xyz";
            }
        }
        catch (Exception ex)
        {
          Debug.WriteLine("error: "+ex);
        } 
      });
