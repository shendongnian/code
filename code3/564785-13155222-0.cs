     string filename = TypeDrp.SelectedValue;
            UserControl userControl;
            switch (filename)
            {
                case "XTypeForm.ascx":
                    UserControl ctrl = (XTypeForm)LoadControl("~/XTypeForm.ascx");
                    PlaceHolder1.Controls.Clear();
                    PlaceHolder1.Controls.Add(ctrl);
                    break;
            }
    
