           using System;
           using System.Collections.Generic;
           using System.ComponentModel;
           using System.Data;
           using System.Drawing;
           using System.Linq;
           using System.Text;
           using System.Windows.Forms;
           using System.Data.SqlClient;
        namespace Artikujt
        {
     public partial class Form1 : Form
      {
         SqlConnection con = new SqlConnection(@"Data Source=TALY-PC;Initial              Catalog=Katalogi;Integrated Security=True;Pooling=False");
    
        DataSet dsl = new DataSet();    
        public Form1()
        {
    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblArtikujt", con);
            InitializeComponent();
        }  
       private void button1_Click(object sender, EventArgs e)
         { SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM    tblArtikujt",           con);
         }  
    }
}
