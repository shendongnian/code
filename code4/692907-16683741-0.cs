    public partial class Form1 : Form
    {
        ComboBox[] cb = new ComboBox[28];
    private void Form1_Load(object sender, EventArgs e)
    {
 
       for (int ii = 0; ii < 28; ii++)
       {
		        cb[ii] = new ComboBox();
                cb[ii].Items.Add("OK");
                cb[ii].Items.Add("NOT OK");
                cb[ii].SelectedIndex = 0; 
                cb[ii].ForeColor = Color.Black;  
                cb[ii].SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
       }
    }
    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx.Text == "OK")
            {
                cbx.ForeColor = Color.Black;
            }
            else
            {
                cbx.ForeColor = Color.Red;
            }
        }
    }
 
   
