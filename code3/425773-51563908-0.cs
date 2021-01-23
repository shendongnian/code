        private void ChangeDefaultButton()
        {
            if (this.TextBox.Focused)
            {
                this.AcceptButton = button;
            }
            else
            {
                this.AcceptButton = button1;
            }
        }
