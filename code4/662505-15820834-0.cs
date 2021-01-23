    public partial class Form1 : Form
    {
       public int choice=0;
       public Form1()
       {
          UpdateForm();
       }
       private void UpdateForm(){
          if(choice == 0)
          {
             label.Text = "Please push one of these buttons :";
             // And there are buttons below this label
          }
          else if(choice == 1)
          {
             label.Text = "You just pushed YES button";
          }
          else if(choice == 2)
          {
             label.Text = "You just pushed NO button";
          }
       }
       private void buttonYes_Click(object sender, EventArgs e)
       {
           choice = 1;
           /*
              I have to use one of these here for redraw whole form
              this.Refresh();
              this.Invalidate();
           */
           UpdateForm();
       }
       private void buttonNo_Click(object sender, EventArgs e)
       {
           choice = 2;
           /*
              I have to use one of these here for redraw whole form
              this.Refresh();
              this.Invalidate();
           */
          UpdateForm();
    
       }
    } 
