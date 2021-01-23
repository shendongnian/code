    if(!(DropDownList1.SelectedItem.Text==""))
    {
        string a = DropDownList1.SelectedItem.Text;
        string [] q  = a.Split('/');
 
        string qq  =    q[1];
        Image1.Visible = true;
        Image1.ImageUrl = "~/Images1/" + qq;
    }
