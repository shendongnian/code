        private void txtSearch_KeyUp(object Sender, KeyEventArgs E)
        {
            int iKeyData = (int)(E.KeyData);
            if (((E.KeyData.HasFlag(Keys.OemMinus) == true) && (E.Shift == true)) || ((iKeyData >= 65) && (iKeyData <= 122)))
            {
                System.Diagnostics.Debug.WriteLine(E.KeyData);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Throw away a " + E.KeyData);
            }
        }
