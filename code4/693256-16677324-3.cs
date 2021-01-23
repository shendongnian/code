    this.button1.Click += new System.EventHandler(this.button_Click);
    this.button2.Click += new System.EventHandler(this.button_Click);
    ...and so on
      private void button_Click(object sender, EventArgs e)
            {
               Thread x= new Thread(new ParameterizedThreadStart(Jogger2));
                x.Start(sender);
              
            }
    
            
            private void setResult(object obj,string text)
            { 
                if (this.textBox1.InvokeRequired)
                {
                    Action<Button,string> d = new Action<Button,string>(setResult);
                    this.Invoke(d,obj,text);
                }
                else
                {
                    Button btn=obj  as Button;
                   if(btn!=null)btn.Text = text;
                }
            }
            private void Jogger2(object mybtn)
            {
                int ii = 0; 
                while (isok)
                {
                    Thread.Sleep(1000);
                        //replace with your code
                        ii += 1;
                         setResult(mybtn,ii.ToString());
                     
                }
    
            }
