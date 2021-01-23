    void YourTextbox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            if (this.CharacterCasing == CharacterCasing.Upper && char.IsLower(e.KeyChar))
            {
                this.Text = this.Text.Insert(this.SelectionStart, char.ToUpper(e.KeyChar) + string.Empty);
                this.SelectionStart++;
                e.Handled = true;
            }
            else if (this.CharacterCasing == System.Windows.Forms.CharacterCasing.Lower && char.IsUpper(e.KeyChar))
            {
                this.Text = this.Text.Insert(this.SelectionStart, char.ToLower(e.KeyChar) + string.Empty);
                this.SelectionStart++;
                e.Handled = true;
            }
        }
    }
