    UpdateItems(Person person)
    {
       // :( probably null for Relatives :(
       GridView myGrid = (GridView)FindControl("MyGrid");
       for (int i = 0; i < myGrid.Rows.Count; i++)
       {
           Textbox txtName = (Textbox)myGrid.Rows[i].FindControl("");
           CheckBox chkSelected = (Checkbox)myGrid.Rows[i].FindControl("");
           Person p = new Person();
           p.Name = txtName.Text;
           p.IsSelected = chkSelected.cheked;
           person.Relatives.Add(p);
        }
        myEntity.SaveChanges();
    
