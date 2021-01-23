    void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {    
            button1.PerformClick();
        }
        base.OnKeyUp(e);
    }
