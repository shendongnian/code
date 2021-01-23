    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class partin : System.Web.UI.Page
    {
    private List<String> books = new List<String>();
    
    public void Page_PreRender()
    {
        Item_Listbox.DataSource = books;
        Item_Listbox.DataBind();
    }
    
    int SortASC(string x, string y)
    {
        return String.Compare(x, y);
    }
    
    int SortDESC(string x, string y)
    {
        return String.Compare(x, y) * -1;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    if(!IsPostBack){
    
        Header_Label.Text = "Welcome! Please select a book category.";
        Item_Listbox.DataSource = books;
        Item_Listbox.DataBind();
    }
    
    }
    
    
    
    protected void Fiction_Click(object sender, EventArgs e)
    {
        Header_Label.Text = "Fiction Section";
    
        books.Add("Title: The Old Man and The Sea | Decription: An epic novel. | Price: 10 USD | Quantity: 3");
        books.Add("Title: A Game of Thrones | Decription: A tale of fire and ice. | Price: 15 USD | Quantity: 6");
        books.Add("Title: Dracula | Decription: A book about vampires. | Price: 5 USD | Quantity: 7");
        books.Add("Title: Twilight | Decription: An awful book. | Price: Free | Quantity: 1000");  
    
    }
    
    
    protected void Non_Fiction_Click(object sender, EventArgs e)
    {
        Header_Label.Text = "Non-Fiction Section";
    
    
    
    }
    protected void Self_Help_Click(object sender, EventArgs e)
    {
        Header_Label.Text = "Self Help Section";
    
    
    
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
    
    }
