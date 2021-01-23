        private void txtJustNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit((char)(e.KeyChar)) &&
                e.KeyChar != ((char)(Keys.Enter)) &&
                e.KeyChar != (char)(Keys.Delete) &&
                e.KeyChar != (char)(Keys.Back))             
            {
                e.Handled = true;
            }
		}
