    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.SQLite;
    
    namespace Project
    {
        public partial class FrmGame : Form
        {
            private string team;
            private string p;
            private List<DataGridViewRow> selected;
            
            //Declare the array here with the public access modifier***
            public int[] Energy = new int[6];
    
            public FrmPartida(string team, List<DataGridViewRow> selected)
            {
                //Code removed for clarity
            }
    
            public void Statistics(DataSet dataset, string team)
            {
                //Code removed for clarity
            }
    
            public void timer1_Tick(object sender, EventArgs e) 
            {
                //Code removed
            } 
        }
    }
