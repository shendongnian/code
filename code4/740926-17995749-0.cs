     listview.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {  
       public void onItemSelected(AdapterView<?> parentView, View childView, int position, long id) {  
           var t = items[position];
            Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
            }
     }); 
