        private delegate void UpdateTextControlDelegate(Control control, string text);
        private void UpdateTextControl(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                Invoke(new UpdateTextControlDelegate(UpdateTextControl), new[] { control, text});
                return;
            }
            control.Text = text;
        }
...
    if (e.Data != null)
    {         
         UpdateTextControl(rchsdtOut, e.Data.ToString());
         Console.WriteLine(e.Data.ToString());
    } 
            
