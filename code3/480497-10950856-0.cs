    class TextListner : TraceListner
    {
        private TextBox tBox;
        
        TextListner( TextBox box)
        {
          this.tBox = box;
        }
        public override void Write(string msg)
        {
           if(box== null) return;
           
           box.Text += msg;
        }
        public override void WriteLine(string msg)
       {
          if(HandleText == null) return;
          Write(msg);
          box.Text += "\r\n";
       }
   }
