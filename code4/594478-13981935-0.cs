    public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (this.CurrentFocus.Id == Resource.Id.etTheIdOfYourEditTextControl && (e.KeyCode == Keycode.NumpadEnter || e.KeyCode == Keycode.Enter))
            {
                InputMethodManager imm = GetSystemService(Context.InputMethodService) as InputMethodManager;
                if (imm != null)
                    imm.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
                return true;
            }
            return base.DispatchKeyEvent(e);
        }
