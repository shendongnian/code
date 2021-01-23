    [Activity(Label = "Spinner Activity")]
    public class SpinnerActivity : Activity
    {
        private List<Users> _users;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LayoutWithSpinner);
            var spinner = FindViewById<Spinner>(Resource.Id.spinner);
            //you need to add data to _users before creating adapter
            var adapter = new CustomSpinnerAdapter(this,_users);
            spinner.Adapter = adapter;
            spinner.ItemSelected += SpinnerItemSelected;
        }
        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Toast.MakeText(this, "Id:"+_users[e.Position].Id +" Name"+_users[e.Position].Name, ToastLength.Long).Show();
        }
    }
