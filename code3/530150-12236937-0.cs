    // Let I have two properties on my page as
     protected string ImageUrl { get; set; }
    protected string Name { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        // Suppose I have the value in a string variable val
       string val = " {Name:'bla bla', ImageUrl:'www.myimago.gif'}";
       // Split them using String.Split function
       string[] array = val.Split(',');
       ImageUrl = array[1].Replace('}',' ');
       Name = array[0].Replace('{',' ');   
    }
  
    // aspx source code
    <%= Name %>        // Output: Name:'bla bla' 
    <%= ImageUrl %>    // Output: ImageUrl:'www.myimago.gif'
