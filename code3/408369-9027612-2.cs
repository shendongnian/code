    private List<String> books
    { 
       get{
             if(ViewState["books"] == null){
                 List<String> books = new List<String>();
                 books.Add("Title: The Old Man and The Sea | Decription: An epic novel. | Price: 10 USD | Quantity: 3");
                books.Add("Title: A Game of Thrones | Decription: A tale of fire and ice. | Price: 15 USD | Quantity: 6");
                books.Add("Title: Dracula | Decription: A book about vampires. | Price: 5 USD | Quantity: 7");
                books.Add("Title: Twilight | Decription: An awful book. | Price: Free | Quantity: 1000");
                 ViewState["books"] = books;
             }
             return new List<String>((String[])ViewState["books"]);
       }
       set{
           ViewState["books"] = value;
       }
    }
    protected void Fiction_Click(object sender, EventArgs e)
    {
            Header_Label.Text = "Fiction Section";
    
            Item_Listbox.DataSource = books;
            Item_Listbox.DataBind();
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
    
        Item_Listbox.DataSource = books;
        Item_Listbox.DataBind();  
    }
