    public static void BUTTON_CAL(object sender, System.Windows.Forms.KeyEventArgs e) 
    {
         var frm = sender as Form;
         if(e.KeyCode==Keys.A&&e.Modifiers==Keys.Control) 
         {  
              if(frm.Controls["AddButton"].Enabled==true)
              {
                 ((Button)frm.Controls["AddButton"]).PerformClick();
              }
              e.SuppressKeyPress=true;
         }
    }
