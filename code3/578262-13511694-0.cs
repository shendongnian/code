    iterate = 0;
    foreach (System.Web.UI.Control ctrl in this.editOkkInfo.Controls)
    {
        if (ctrl is TextBox)
        {
            tb = (TextBox)ctrl;
            tb.Text = dt.DefaultView[0][iterate++].ToString();
        }
        if (iterate == 14)
            break;
    }
