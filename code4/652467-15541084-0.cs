      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
    
          gridControl1.DataSource = new List<Structure>
            {
              new Structure {Id = 1, Val1 = "nr 1"}, 
              new Structure {Id = 2, Val1 = "nr 2"}, 
              new Structure {Id = 3, Val1 = "nr 3"}
            };
        }
    
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
           int myExpectedRowHandle = 1;
           if (e.RowHandle == myExpectedRowHandle)
           {
             e.Appearance.BackColor = Color.Crimson;
           }
        }
      }
    
      public class Structure
      {
        public string Val1 { get; set; }
        public int Id { get; set; }
      }
