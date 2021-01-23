     public delegate void LoginDelegate(string s);
     public partial class AirLineReservationMDI : Form
        {
            LoginDelegate loginAirLineDelegate;
    
        }
    loginAirLineDelegate = new LoginDelegate(DisableToolStripMenuItems);
 
     public void DisableToolStripMenuItems(string s)
            {
               this.viewToolStripMenuItem.Visible = true;
                this.bookingToolStripMenuItem.Visible = true;
                this.existingUserToolStripMenuItem.Visible = false;
                this.newUserToolStripMenuItem.Visible = false;
                this.toolStripStatusUserID.Text = "USerID :- "+s;             
               this.LoginUserId = s;
            }
