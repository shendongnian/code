    class Cell : UserControl
    {       
        Label lbl;
        public Cell()
        {
            lbl = new Label();
            lbl.Parent = form;        
            lbl.Height = 30;
            lbl.Width = 30;
            this.Controls.Add(lbl); // label is now contained by 'Cell'
        }
    } 
