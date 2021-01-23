    EditText zipcode = FindViewById<EditText>(Resource.Id.zipcode);
	zipcode.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
		if(zipcode.Text.Length >= 5){
			zipcode.InputType = Android.Text.InputTypes.ClassText;
		}
		if(zipcode.Text.Length <= 4){
			zipcode.InputType = Android.Text.InputTypes.ClassNumber;
		}
    };
