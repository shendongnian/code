    private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            Boolean Capslock = Console.CapsLock;
            if (Capslock == true)
            {
                PopupTextBlock.Text = "Caps Lock is On.";
                txtPasswordPopup.IsOpen = true;
            }
            else
            {
                txtPasswordPopup.IsOpen = false;
            }
        }
