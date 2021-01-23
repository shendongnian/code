        public void Initialize()
        {
            SetPlaceHolder(loginTextBox, " Логин ");
            SetPlaceHolder(passwordTextBox, " Пароль ");
        }
        public void SetPlaceHolder(Control control, string PlaceHolderText)
        {
            control.Text = PlaceHolderText;
            control.GotFocus += delegate(object sender, EventArgs args) {
                if (control.Text == PlaceHolderText)
                {
                    control.Text = "";
                }
            };
            control.LostFocus += delegate(object sender, EventArgs args){
                if (control.Text.Length == 0)
                {
                    control.Text = PlaceHolderText;
                }
            };
        }
