    for (int i = 0; i < maxlabels ; i++)
    {                
            Label x = new Label();
            x.Name = string.Format("label{0}", i);
            x.Text = x.Name;
            x.BackColor = Color.Transparent;
            yourFlowLayoutPanel.Controls.Add(x);                
    }
