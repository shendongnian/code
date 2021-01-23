     private void AppendValidationErrorMessage( string message)
        {
            var cv = new CustomValidator(); 
            cv.IsValid = false;
            cv.ErrorMessage = message;
            cv.ValidationGroup = "PageValidationGroup";
            this.Page.Validators.Add(cv);
        }
        protected void SubmitButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.CaptchaUserControl.ValidateCaptcha(CapthaTextBox.Text.GetTrimValue());
                if (!this.CaptchaUserControl.UserValidated)
                {
                    this.AppendValidationErrorMessage(this.CaptchaUserControl.CustomValidatorErrorMessage);
                }
            }
            catch (Exception)
            {
                this.AppendValidationErrorMessage(
                    "Captcha expired please please reload the page.Note: please copy the data before refreshing data");
            }
            this.CapthaTextBox.Text = string.Empty;
            if (this.Page.IsValid) //&& this.CaptchaUserControl.UserValidated
            {
                //do something
            }
        }
