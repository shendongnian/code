    public ActionResult DeleteResource(RoomModel roomModel)
    {
      // process checkbox values
      foreach(var checkbox in roomModel.Resources)
      {
        // grab values
        string resource = checkbox.Key;
        bool isResourceChecked = checkbox.Value;
        //process values...
        if(isResourceChecked)
        {
          // delete the resource
        }
        // do other things...
      }
    }
