    Form formx = new Form();
    formx.Tag = "form14";
    formx.Show();
    ...
      void button_click(object sender,...)
      {
            CloseTagedForm("form14");
      }
    ...
            public void CloseTagedForm(string myTag)
            {
                foreach (Form frm in Application.OpenForms)
                    if (frm.Tag != null && frm.Tag.ToString() == myTag)
                        frm.Close();
            }
