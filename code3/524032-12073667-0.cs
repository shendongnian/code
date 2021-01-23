    //Form2.cs 
  
     public class Form2 : Form
     {
        ..... 
    
        public override OnLoad(EventArgs e)
        { 
           ......
           if (!sdr.HasRows)
           {
              MessageBox.Show("No Data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              this.Close();
            }
        }   
    
     
      }
