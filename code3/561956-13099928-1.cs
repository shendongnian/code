    public class Activity2 : Activity
    {
        string itemContent;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout1);
            var textView1 = new TextView(this);
            EditText editTxt = FindViewById<EditText>(Resource.Id.editTxt);
            itemContent = Intent.GetStringExtra("username");
            editTxt.Text = itemContent;
        }
    }
