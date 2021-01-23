    public partial class Default : System.Web.UI.Page 
    { 
        private int clickcount = 0; 
        public virtual void button1Clicked (object sender, EventArgs args) 
        { 
        	if (Session["clickcount"] != null)
        		clickcount = (int)Session["clickcount"];
        		
            clickcount++; 
            Session["clickcount"] = clickcount;
            
            button1.Text = "You clicked me "+clickcount.ToString()+" time"; 
        } 
        public virtual void GreetButtonClicked (object sender, EventArgs args) 
        { 
            GreetButton.Text = "Hello "+TextInput.Text; 
        } 
    }
