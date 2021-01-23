     public partial class frmWorldEmail : Form
     {
          public frmWorldEmail(string names, string emails)
          {
             InitializeComponent();
             lstNameTo.Items.Add(names);
             lstEmailTo.Items.Add(emails);
          }     
      }
