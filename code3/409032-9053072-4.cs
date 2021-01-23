    public partial class partin : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    string[] categories = new string[] { "fiction", "non_fiction", "self_help" };
                    Category_DropDownList.DataSource = categories;
                    Category_DropDownList.DataBind();
                    Header_Label.Text = "Welcome! Please select a book category.";
                    string categorySelected = Request.Form["Cat_DropDownList"];
                    ShowBooks(categorySelected);
                } 
            }
    
            private void ShowBooks(string category)
            {
                Item_Listbox.Items.Clear();
                List<string> books = null;
                switch(category)
                {
                    case "fiction" :
                        Header_Label.Text = "Fiction Section";
                        books = GetFictionBooks();
                        break;
                    case "non_fiction":
                        Header_Label.Text = "Non-Fiction Section";
                        books = GetNonFictionBooks();
                        break;
                    case "self_help":
                        Header_Label.Text = "Self Help Section";
                        books = GetSelfHelpBooks();
                        break;
                }
                books.Add(GetBookAddedToForm());
                Item_Listbox.DataSource = books;
                Item_Listbox.DataBind(); 
            }
    
            private string GetBookAddedToForm()
            {
                string bookDetails  = "Title: " + Request.Form["Titletxt"] + " | " + "Description: " + Request.Form["Descriptiontxt"] + " | " + "Price: " + Request.Form["Pricetxt"] + " | " + "Quantity: " + Request.Form["Quantitytxt"];
                return bookDetails;
            }
    
            protected List<string> GetFictionBooks()
            {
                List<String> books = new List<String>(); 
                books.Add("Title: The Old Man and The Sea | Decription: An epic novel. | Price: 10 USD | Quantity: 3");
                books.Add("Title: A Game of Thrones | Decription: A tale of fire and ice. | Price: 15 USD | Quantity: 6");
                books.Add("Title: Dracula | Decription: A book about vampires. | Price: 5 USD | Quantity: 7");
                books.Add("Title: Twilight | Decription: An awful book. | Price: Free | Quantity: 1000");
                return books;
            } 
    
            private List<string> GetNonFictionBooks()
            {
                List<string> books = new List<string>();
                books.Add("Title: zzzThe Old Man and The Sea | Decription: An epic novel. | Price: 10 USD | Quantity: 3"); 
                books.Add("Title: zzzA Game of Thrones | Decription: A tale of fire and ice. | Price: 15 USD | Quantity: 6"); 
                books.Add("Title: zzzDracula | Decription: A book about vampires. | Price: 5 USD | Quantity: 7"); 
                books.Add("Title: zzzTwilight | Decription: An awful book. | Price: Free | Quantity: 1000");
                return books;
            }
    
            private List<string> GetSelfHelpBooks()
            {
                return new List<string>();
            }
