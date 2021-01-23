    private void all_CheckedChanged(object sender, EventArgs e)
    {
        if (!m_all.Focused)
         return ;
        if (m_all.Checked)
        {
            foreach (CheckBox cb in m_attributes)
            {
                cb.Checked = true;
            }
        }
        else
        {
            foreach (CheckBox cb in m_attributes)
            {
                cb.Checked = false;
            }
        }
    }
