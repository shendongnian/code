     private void ThisAddIn_Startup(object sender, System.EventArgs e)
     {
       Task.Factory.StartNew(() => {
           //Thread.Sleep(1000); // optional
           Application.SendKeys("^{F1}");
       }, TaskCreationOptions.AttachedToParent);
     }
