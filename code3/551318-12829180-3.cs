    protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.IsRepeat)
            {
                if (((KeyGesture)altD.Gesture).Matches(this, e))
                {
                    e.Handled = true;
                }
                else if (e.Key == Key.System)
                {
                    string sysKey = e.SystemKey.ToString();
                    //We only care about a single character here: _{character}
                    if (sysKey.Length == 1 && AccessKeyManager.IsKeyRegistered(null, sysKey))
                    {
                        e.Handled = true;
                    }
                }
            }
        }
