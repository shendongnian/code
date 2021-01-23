    public partial class YourFormName
    { 
        private bool IsReady= false;
        
        private void YourFormName_Load(object sender, EventArgs e)
        { 
               //Load your GridView1...
               //Format your GridView1...
                IsReady = true;
        }
        void GridView1_SelectionChanged(object sender, EventArgs e)
        {
             if (!IsReady) 
                 return;
             //do the rest of the stuffs
        }
    }
