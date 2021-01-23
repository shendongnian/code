    public void AppendText(string what, bool debug = false)
         {
             if (debug)
                 return;
             if (this.InvokeRequired)
             {
                 this.Invoke(
                     new MethodInvoker(
                     delegate() { AppendText(what); }));
             }
             else
             {
                 DateTime timestamp = DateTime.Now;
                 tbox.AppendText(timestamp.ToLongTimeString() + "\t" + what + Environment.NewLine);
             }
         }
