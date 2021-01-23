    public class Program
    {
         //This method is the one that sets up the 
         //instance and subscribes to the event
         public void CallingMethod()
         {
             Connection con = new Connection();
             //Specifies that con_DataSent is to be 
             //executed whenever this event is raised
             con.DataSent += new EventHandler(con_DataSent);
         }
         void con_DataSent(object sender, EventArgs e)
         {
             //Put your subscription logic here.
             //Whatever you want to do in response to a send
         }
    }
