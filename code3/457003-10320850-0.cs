        string[] list = new string[form1.ckdBoxList.Items.Count];
        MessageBox.Show(form1.ckdBoxList.Items.Count+"");//In debug it tells me that the lenght is 0
        for (int i = 0; i < form1.ckdBoxList.Items.Count; i++)
        {
            list[i] = form1.ckdBoxList.Items[i].ToString();
        }
