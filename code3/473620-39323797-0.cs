     // Declaring array of TextBox
    private System.Windows.Forms.TextBox[] txtArray;
    private void AddControls(int cNumber)
    {
    
                // assign number of controls
    
                txtArray = new System.Windows.Forms.TextBox[cNumber + 1]; 
    
                for (int i = 0; i < cNumber + 1; i++)
    
                {
    
                            // Initialize one variable
    
                            txtArray[i] = new System.Windows.Forms.TextBox();
    
                }
    }
