    myFormConstructor()
    {    
           //Panel or Container control or collection that is persistant can be used to hold buttons that will be created dynamically i.e. 9 buttons to this panel in our case
           for(int i = 1 ; i <= 9 ; i++)
           {
               var btn = new Button{
                                     Name = "btn"+i.ToString()
                                     Text = i.ToString()
                                   });
    
               btn.Click += new System.EventHandler(listener_button_click);
               pnl.Controls.Add(btn);    
           }
    }
    ///Write common logic for each button using if else
    private void listener_button_click(object sender, EventArgs e) 
    {
        
        var btnName = ((Button)sender).Name;
                switch (btnName)
                {
                    case "btn1":
                        //handler for btn1 click
                        break;
                    case "btn2":
                        //handler for btn2 click
                        break;
                }    
        }
