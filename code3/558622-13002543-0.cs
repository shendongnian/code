     while ((line = sr.ReadLine()) != null )
     {
       var theLine = line;
       this.Invoke((MethodInvoker)delegate
       {
           richTextBox1.AppendText(theLine + Environment.NewLine);
           richTextBox1.ScrollToCaret();   
       });
     }
