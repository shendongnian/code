        public delegate void MyDelegate(string message);
    
       //when you have to use Invoke method, call this one:
       private void UpdatingRTB(string str)
       {
           if(richTextBox8.InvokeRequired)
               richTextBox8.Invoke(new MyDelegate(UpdatingRTB), new object []{ msg });
           else
               richTextBox8.AppendText(msg);
       }
