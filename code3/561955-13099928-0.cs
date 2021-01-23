           protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.sendBtn);
            EditText editText = FindViewById<EditText>(Resource.Id.editText1);
            button.Click += delegate
            {
                string username = editText.Text.ToString();
                Intent intent = new Intent();
                intent.SetClass(this, typeof(Activity2));
                intent.PutExtra("username", editText.Text);
                StartActivity(intent);
            };
        }
