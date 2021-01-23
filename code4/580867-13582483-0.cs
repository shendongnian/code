    private class ComboBoxEx : System.Windows.Forms.ComboBox
        {
            Int32 _lastIndex = -1;
            protected override void OnSelectedIndexChanged(System.EventArgs e)
            {
                if (_lastIndex == -1)
                {
                    _lastIndex = this.SelectedIndex;
                    base.OnSelectedIndexChanged(e);
                }
                else
                    if (_lastIndex != this.SelectedIndex)
                    {
                        base.OnSelectedIndexChanged(e);
                        _lastIndex = this.SelectedIndex;
                    }
            }
        }
