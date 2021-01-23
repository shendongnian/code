    for (int i = 0; i < 13; i++)
            {
                Form frm = new Form();
                frm.Tag = "form" + i.ToString();
                frm.Text = "form" + i.ToString();
                frm.Show();
            }
    ...
      void button_click(object sender,...)
      {
            CloseTagedForm("form14");
      }
    ...
            public void CloseTagedForm(string myTag)
            {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)//when you have to change the items you should do a reverse loop !
                if (Application.OpenForms[i].Tag != null && Application.OpenForms[i].Tag.ToString() == myTag)
                    Application.OpenForms[i].Close();
            }
