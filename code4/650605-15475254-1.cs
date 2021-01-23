    EditText zipcode = FindViewById<EditText>(Resource.Id.zipcode);
	zipcode.InputType = Android.Text.InputTypes.ClassNumber;
	bool fromLetters = true;
	zipcode.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
		if(zipcode.Text.Length == 4){
			if(fromLetters){
				fromLetters = false;
				zipcode.Text = zipcode.Text + " ";
				zipcode.SetSelection(zipcode.Text.Length);
			}
		}
		if(zipcode.Text.Length > 4){
			fromLetters = false;
			zipcode.InputType = Android.Text.InputTypes.ClassText;
		}
		if(zipcode.Text.Length <= 4){
			fromLetters = true;
			zipcode.InputType = Android.Text.InputTypes.ClassNumber;
		}
	};
