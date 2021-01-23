    class MyDialog : Form
        {
            //your properties like buttons and all goes here
        private Button okButton;
        private Button cancelButton;
   
            okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(20, 260);
            okButton.Size = new Size(80, 25);
            okButton.Text = "OK";
            okButton.Click += new EventHandler(okButton_ClickCompany);
            Controls.Add(okButton);
            //same implementation for all other controls you define
        }
