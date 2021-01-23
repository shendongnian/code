    public partial class Default : System.Web.UI.Page
    {
        public int clickcount 
      {
       get
       {
         if(Viewstate["clickcount"] != null)
         {
          return (int)Viewstate["clickcount"]; //Need to cast the viewstate object in int.
         }
         else
         {
            return 0;
          }
      }
       set
       {
         Viewstate.add("clickcount",value);
       }
      }
        public virtual void button1Clicked (object sender, EventArgs args)
        {
            clickcount++;
            button1.Text = "You clicked me "+clickcount.ToString()+" time";
        }
        public virtual void GreetButtonClicked (object sender, EventArgs args)
        {
            GreetButton.Text = "Hello "+TextInput.Text;
        }
         }
