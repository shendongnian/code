        // This code sample requires `using System.Reflection;` and `using System.Web`
        private void ButtonClick(object sender, EventArgs e)
        {
            // Figure out which button was clicked
            var clicked = sender as Button;
            // Determine the label we want to read based on the button's tag property
            var relatedLabelField = this.GetType().GetField(clicked.Tag.ToString());
            if (relatedLabelField == null)
                return;
            // Get the label from our form
            var relatedLabel = relatedLabelField.GetValue(this) as Label;
            if (relatedLabel == null)
                return;
            // Create the TTS API URL including our labels text escaped
            PlayMp3FromUrl("http://translate.google.com/translate_tts?q=" + HttpUtility.UrlEncode(relatedLabel.Text));
        }
