    bool allowItemAdding;
    
    private void Lightnings_Mode_Load(object sender, EventArgs e)
    {
        allowItemAdding = false; //setting false here because *sometimes* Load event is called multiple times.
        this.Size = new Size(416, 506);
        this.Location = new Point(23, 258);
        listBoxIndexs();
        this.listBox1.SelectedIndex = 0;  
        allowItemAdding = true; //set flag to true after selecting the index initially
    }
    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {          
         item = listBox1.SelectedItem.ToString();
         this.f1.PlayLightnings();
         f1.pdftoolsmenu();
         if (allowItemAdding)
         {
             if (item != null && !pdf1.Lightnings.Contains(item.ToString()))
             {
                 pdf1.Lightnings.Add(item.ToString());             
             }
         }
    }
