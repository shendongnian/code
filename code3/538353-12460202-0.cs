     void btn1_onchange(object sender, EventArgs e)
      {
        MessageBox.Show("Number One");
      }
    
      void btn1_onchange2(object sender, EventArgs e){
        MessageBox.Show("Number Two");
      }
    
      public MyForm() {
       
    
        Button btn1 = new Button();
        btn1.Text = "Click Me";
        this.Controls.Add(btn1);
    
        btn1.TextChange += new EventHandler(btn1_onchange);
        btn1.TextChange += new EventHandler(btn1_onchange2);
      }
