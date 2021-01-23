    changeImageButton.Tap += (s, e) =>
    {
        try
        {
           PhotoChooserTask pct_edit = new PhotoChooserTask();
           pct_edit.ShowCamera = true;
           pct_edit.Completed += (s,e) =>
           {
               if (e.TaskResult == TaskResult.OK)
               {
                  var bi = new BitmapImage() // maybe you didn't initial  bi?
                  bi.SetSource(e.ChosenPhoto);
                  IsRebuildNeeded = true;
               }
           }
           pct_edit.Show();
        }
        catch (Exception ex)
        {
           Message.Show(ex.Message);
        }
    };
