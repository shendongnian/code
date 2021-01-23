     public void ChangeControlStatus(ControlCollection PageControls, int Role_id,string Submenu_Name,RepeaterItemEventArgs e)
    {
     foreach (Control ctrl in PageControls)
            {
               
                string ControlName = (ctrl.GetType()).Name;
                switch (ControlName)
                {
                    case "ImageButton":
                        ImageButton imgbut = (ImageButton)ctrl;
                        ImageButton img_but_delte = e.Item.FindControl("lnkDelete") as ImageButton;
                        ImageButton img_but_edit = e.Item.FindControl("lnkEdit") as ImageButton;
                        {
                            
                            foreach (var role in Role_Assigned)
                            {
                                if(role.ADD_ACCESS == false)
                                    if (imgbut.ID.Equals("btnAdd"))
                                        imgbut.Enabled = false;
                                if (role.DELETE_ACCESS == false)
                                        img_but_delte.Enabled = false;
                                
                                if (imgbut.ID.Equals("btnlogout"))
                                        img_but_edit.Enabled = false;
                            }
                        }
                        break;
                }
                ChangeControlStatus(ctrl.Controls, Role_id,Submenu_Name,e);
            }
        }
