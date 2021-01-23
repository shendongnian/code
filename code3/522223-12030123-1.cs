    private void button11_Click(object sender, EventArgs e)
    {
        T1 = new Thread((ThreadStart)delegate
        {
            UlozHlasovanie();
        });
        T1.Name = "asd";
        T1.Start();
        while (T1.IsAlive) { Application.DoEvents(); }
        krok = 4;
        panel1.Visible = false;
        panel2.Visible = false;
        panel3.Visible = false;
        panel4.Visible = true;
        panel5.Visible = false;
        panel6.Visible = false;
        richTextBox1.Text = "";
        foreach (DataGridViewRow row in dataGridView2.Rows)
        {
            row.Cells["rozhodnutie"].Value = null;
        }
    }
