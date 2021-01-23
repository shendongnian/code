    this.button1.Click += new System.EventHandler(this.button_Click);
    this.button2.Click += new System.EventHandler(this.button_Click);
    ...and so on
      private void button_Click(object sender, EventArgs e)
            {
               Thread x= new Thread(new ParameterizedThreadStart(Jogger2));
                x.Start(sender);
              
            }
    
            
            private void button_Click(object sender, EventArgs e)
        {
            Button mybtn=sender as Button;
            if((string)mybtn.Tag=="start"){
                mybtn.Tag ="";
                return;
             }
            mybtn.Tag = "start";
           Thread x= new Thread(new ParameterizedThreadStart(Jogger2));
            x.Start(sender);
          
        }
    
        
        private bool  setResult(object obj,string text)
        { 
            if (this.textBox1.InvokeRequired)
            {
                Func<Button,string, bool > d = new Func<Button,string,bool >(setResult);
                return (bool)this.Invoke(d,obj,text);
                
            }
            else
            {
                Button btn=obj  as Button;
    
                if (btn != null)
                {
                    btn.Text = text;
                    if ((string)btn.Tag !="start") return false;
                }
                return true;
            }
        }
        private void Jogger2(object mybtn)
        {
            int ii = 0; 
            while (true)
            {
                Thread.Sleep(1000);
                    //replace with your code
                    ii += 1;
                    if (!setResult(mybtn, ii.ToString())) break; 
                 
            }
    
        }
