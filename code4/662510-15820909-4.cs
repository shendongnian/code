    public partial class Form1 : Form
    {
      public Form1()
      {
        label.Text = "Push a button";
        buttonYes.Click += (s,e) => {label.Text = "Yes is pressed";};
        buttonNo.Click += (s,e) => {label.Text = "No is pressed";};
      }
    }
   
