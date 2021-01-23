    var g = 0;
    foreach (Control ctrl in Controls)
    {
        if (ctrl is UserControl1)
        {
            var myCrl = ctrl as UserControl1;
            g += Convert.ToInt32(myCrl.textbox2.Text);
        }
    }
    //Set your label's text
