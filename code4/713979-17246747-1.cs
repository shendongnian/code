    public partial class frmCredentials : Form
    {
       private Associate _associate;
        public frmCredentials(Associate _associate)
        {
            InitializeComponent();
            this._associate = _associate;
           //Put in values for MES system and username
           this.label1.Text = "Please enter your " + _associate.mesType + " password";
           this.txtUsername.Text = _associate.userName;
           //Change form color for MES system
           if (_associate.mesType == "FactoryWorks")
           {
              this.BackColor = System.Drawing.Color.Aquamarine;
           }
           else
           {
              this.BackColor = System.Drawing.Color.Yellow;
           }
      }
      private void btnOk_Click(object sender, EventArgs e)
      {
         // you can use _associate object in here since it's an instance field
         //Make sure associate has filled in fields
         if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
         {
              MessageBox.Show("You must enter a Username and Password");
              return;
          }
          this.Visible = false;
          return ;
      }
     }
