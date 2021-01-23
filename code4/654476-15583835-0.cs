    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(ProcesControls(this));
    }
    private string ProcesControls(Control parent)
    {
        string s = "";
        foreach (Control c in parent.Controls)
        {
            if (c.HasChildren)
                s+=ProcesControls(c);
            s += c.Text;
        }
        return s;
    }
