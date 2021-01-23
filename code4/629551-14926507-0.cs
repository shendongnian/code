    //IF VALUE ISN'T NUMERICAL OR NOTHING IS LEFT AFTER REMOVING ZEROS AND SPACES, CHANGE TEXT BACK TO ORIGINAL
    Regex regex = new Regex("[^0-9]+");
    if (regex.IsMatch(this.Text) || this.Text.Length < 1)
    {
        // this.Text = originalText;
        base.SetCurrentValue(TextProperty, originalText);
        System.Media.SystemSounds.Beep.Play();
    }
