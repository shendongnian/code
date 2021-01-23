     System.Collections.Generic.Dictionary<string,System.Windows.Forms.DataGridView>
              grids = new Dictionary<string,System.Windows.Forms.DataGridView>();
             for (int i = 1; i <nCounter ; i++)
                {
                  grids.Add("dv" + i.ToString(), new DataGridView());            
               
                }
        
              // to work on grid 1
             DataGridView grid1 = grids["dv1"];
              // so on
