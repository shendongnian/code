    private void button7_Click(object sender, EventArgs e)
    {
        double s = double.Parse(dataGridView1.Rows[1].Cells[1].Value.ToString());
        double t = double.Parse(dataGridView2.Rows[0].Cells[6].Value.ToString());
        double k = double.Parse(dataGridView3.Rows[0].Cells[1].Value.ToString());
        double l = double.Parse(dataGridView4.Rows[0].Cells[4].Value.ToString());
        double m = double.Parse(dataGridView5.Rows[0].Cells[2].Value.ToString());
        double n = double.Parse(dataGridView6.Rows[0].Cells[3].Value.ToString());
    
        double[] kupoven = new double[] { s,t,k,l,m,n};
        double max = kupoven.Max();
    }
