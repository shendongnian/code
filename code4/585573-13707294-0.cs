    private void btnPressButton_Click(object sender, EventArgs e)
    {
        KeyboardManager.PressKey(KeyCode.CapsLock);
        Application.DoEvents();
        lblKeyboardState.Text = IsKeyLocked(Keys.CapsLock).ToString();
    }
