    try
    {
        string filter = textBoxFilter.Text.Trim();
        dataGridView1.DataSource = new BindingList<YOUR_ENTITY>(Ctx.MyEntitySet.Local.ToBindingList().Where(x => x.EntityPropertyToSearchIn1.ToUpper().Contains(filter)).ToList<YOUR_ENTITY>());
        textBoxFilter.BackColor = SystemColors.AppWorkspace;
    }
