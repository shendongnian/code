      private void ApplicationProperties_FormClosing(object sender, FormClosingEventArgs e)
      {
            //Hiding the window, because closing it makes the window unaccessible.
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
       }
    
