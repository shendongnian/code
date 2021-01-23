    sp.DataReceived += delegate 
         {
             if (tb.InvokeRequired)
             {
                tb.Invoke(new Action(() =>
                {
                    tb.Text += sp.ReadExisting(); 
                }));
             }
             else
             {
                tb.Text += sp.ReadExisting(); 
             }
         }
