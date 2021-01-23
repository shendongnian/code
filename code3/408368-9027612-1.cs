    protected void Fiction_Click(object sender, EventArgs e)
    {
    
            Header_Label.Text = "Fiction Section";
    
            books.Add("Title: The Old Man and The Sea | Decription: An epic novel. | Price: 10 USD | Quantity: 3");
            books.Add("Title: A Game of Thrones | Decription: A tale of fire and ice. | Price: 15 USD | Quantity: 6");
            books.Add("Title: Dracula | Decription: A book about vampires. | Price: 5 USD | Quantity: 7");
            books.Add("Title: Twilight | Decription: An awful book. | Price: Free | Quantity: 1000");
    
            Item_Listbox.DataSource = books;
            Item_Listbox.DataBind();
    
            ViewState["books"] = books;
    
    }
    
    protected void Sort_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sort")
        {
            switch (e.CommandArgument.ToString())
            {
                case "ASC":
                    books.Sort(SortASC);
                    break;
                case "DESC":
                    books.Sort(SortDESC);
                    break;
            }
    
        }
    
        if (ViewState["books"] == null)
            ViewState["books"] = new String[0];
    
        Item_Listbox.DataSource = new List<String>((String[])ViewState["books"]);
        Item_Listbox.DataBind();  
    }
