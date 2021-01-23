    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        { if ((msg.Msg == WM_KEYDOWN) && ModifierKeys == Keys.Control && !_isKeyDown)
            {
                _isKeyDown = true;
                ShowShortCutToolTips();
                this.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
       protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if(e.KeyValue == 17 || e.Control) // 17 = Control Key
            {
                _isKeyDown = false;
                HideShortCutToolTips();
            }
        }
