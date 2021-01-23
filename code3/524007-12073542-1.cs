     spinTime = FindViewById<Spinner>(Resource.Id.spinTimeChoose);
     List<string> spinnerItems = new List<string>();
     ArrayAdapter adapter  new ArrayAdapter<string> (this,Android.Resource.Layout.SimpleSpinnerItem,spinnerItems);
                 
     adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
     spinTime.Adapter = adapter;
     spinTime.ItemSelected += (s, e) =>
     { 
      Log.Debug("SpinnerItems", spinnerItems[e.Position]);           
     }
