     private void txtLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
