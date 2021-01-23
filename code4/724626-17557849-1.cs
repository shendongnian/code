    private Dictionary<string, Image> _table = new Dictionary<string, Image>();
    
    private void frmQuickSpark_Load(object sender, EventArgs e)
        {
            _table.Add("Image1", Properties.Resources.Card_1);
            _table.Add("Image2", Properties.Resources.Card_2);
            Button btn = new Button();
            SetButtonImage(btn);
            DeleteCard(btn);
        }
     private void SetButtonImage(Button button)
        {
            
            button.BackgroundImage = _table["Image1"];
            button.BackgroundImage.Tag = "Image1";
        }
        private void DeleteCard(Button btn)
        {
             if (btn.BackgroundImage.Tag == "Image1") 
             {
                 playersCards.Remove(btn); // not sure what your logic of removal
                 MessageBox.Show(playersCards.Count.ToString());
             }
             else
             {
                 MessageBox.Show("NO");
             }
         }
