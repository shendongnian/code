    protected override void OnListItemClick(ListView listview, 
                                               View view, int pos, long id)
      {
         var selectedvalue = clubs[pos];
        // start new Activity here....
        var intent = new Intent(this, typeof(Your_Next_Activity));
        intent.PutExtra("selectedvalue", selectedvalue);
        StartActivity(intent);
      }
