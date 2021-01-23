    private void SetButton(int id, Button btn)
    {
        var count = chk.GetCount(i);
        if (count == -1)
        {
            btn.Visible = false;
        }
        else
        {
            btn.Text = String.Format("Next dep{0}[{1}]", id.ToString(), count.ToString());
            if (count == 0)
                btn.Enabled = false;
        }
    }
