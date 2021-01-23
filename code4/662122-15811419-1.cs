    private void RefreshFormWithModel(Basic basic)
    {
        labelHP.Text = basic.HP;
    }
    public void buttonInventory_Click(object sender, EventArgs e)
    {
        Basic.HP = Basic.HP++;
        this.RefreshFormWithModel(Basic);
    }
