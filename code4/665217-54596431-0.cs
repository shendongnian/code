    //Create an Empty Form with TopMost & TopLevel attributes.
    Form popup = new Form() { TopMost = true, TopLevel = true };
    
    //Running MessageBox on a different Thread
                  Invoke((MethodInvoker)delegate {
     
         DialogResult dialogResult = MessageBox.Show(popup, "Custom Message Here", MessageBoxButtons.YesNo);
                  if (dialogResult == DialogResult.Yes)
                  {
                      
                      //do something
                  }
                  else if (dialogResult == DialogResult.No)
                  {
                      //do something else
                  }
     
    //Or a casual message box
     
    //MessageBox.Show(popup, "Custom Message Here", "Alert");
     
     });
