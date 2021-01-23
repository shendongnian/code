    public class myForm
    {
         //This method is the one that sets up the 
         //instance and subscribes to the event
         public myForm()
         {
             Connection con = new Connection();
             con.DataSending += new EventHandler(con_DataSending);
             con.DataNotSending += new EventHander(con_DataNotSending);
         }
         void con_DataSending(object sender, EventArgs e)
         {
             //Put your subscription logic here.
             //Whatever you want to do in response to a send
         }
         void con_DataNotSending(object sender, EventArgs e)
         {
             //Put your subscription logic here.
             //Respond to it not sending
         }
    }
