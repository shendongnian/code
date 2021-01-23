        protected override void OnInit(EventArgs e)
        {  
            AddConfirmationButton();   
            base.OnInit(e);
        }
        private void AddConfirmationButton()
        {   
            Button confirmButton = new Button();
            confirmButton.Text = "Action Foo";
            string confirmationMessage = "Are you sure you wish to do action Foo?";
            confirmButton.OnClientClick = "return confirm('" + confirmationMessage + "');";
            confirmButton.Command += confirmButton_Command;
           
            Controls.Add(confirmButton);
        }
        void confirmationMessage_Command(object sender, CommandEventArgs e)
        {
            DoActionFoo();   //work your magic here.
        }
