    EditText zipcode = FindViewById<EditText>(Resource.Id.zipcode);
	zipcode.InputType = Android.Text.InputTypes.ClassNumber;
	bool numberMode = true;
	zipcode.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
		if(zipcode.Text.Length == 4){
			if(numberMode){
				numberMode = false;
				zipcode.Text = zipcode.Text + " ";
				zipcode.SetSelection(zipcode.Text.Length);
			}
		}
		if(zipcode.Text.Length > 4){
			numberMode = false;
			zipcode.InputType = Android.Text.InputTypes.ClassText;
		}
		if(zipcode.Text.Length <= 4){
			numberMode = true;
			zipcode.InputType = Android.Text.InputTypes.ClassNumber;
		}
	};
