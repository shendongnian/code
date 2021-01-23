        public ErrorProvider mProvider;
        public void SetError(Control ctl, string text)
        {
            if (string.IsNullOrEmpty(text)) mErrors.Remove(ctl);
            else if (!mErrors.Contains(ctl)) mErrors.Add(ctl);
            mProvider.SetError(ctl, text);
            ActiveControl = ctl;
        }
