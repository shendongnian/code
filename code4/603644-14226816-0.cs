    Set a break variable;
    
        private volatile bool shouldStop = false;
        public void btm_Processing_Click(object sender, EventArgs e)
        {
           
          for (int i = 1; i <= x ; i++)
                    {
                       //My Processing Commands are Here 
                    }
            if(shouldStop){break;}
        }
    
    private void btm_Stop_Click(object sender, EventArgs e)
            {
    
                DialogResult dialogResult = MessageBox.Show("Do You Want To Stop Processing ? ", "Error", MessageBoxButtons.YesNo);
    
                if (dialogResult == DialogResult.Yes)
                {
                  // Here is Where i want to Break That Loop  
                 shouldStop = true;              
    
                }
                else if (dialogResult == DialogResult.No)
                {
    
    
                }
    
    
    
    
        }
