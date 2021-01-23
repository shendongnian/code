     if(!Page.IsPostBack)
     {  
            //Create two ArrayLists for sorting items
            ArrayList listItems1 = new ArrayList();
            ArrayList listItems2 = new ArrayList();
   
            int q1=Convert.ToInt16(TextBox1.Text);
            for (int i = 1; i <= q1; i++)
            { 
                string t1 = DroDownList1.SelectedItem.ToString().Trim();
                //Add items hereusing .Add() method of ArrayList
                listItems1.Add(string.Concat(t1, i));
                listItems2.Add(DropDownList1.SelectedItem.Text);
            }
            //Sort your items using .Sort() method of ArrayList
            listItems1.Sort()
            listItems2.Sort()
            //Bind your items to your CheckBoxLists
            CheckBoxList1.DataSource = listItems1;
            CheckBoxList2.DataSource = listItems2;  
            CheckBoxList1.DataBind();
            ChackBoxList2.DataBind();  
        } 
