        List<string> listofstring = new List<string>() {"A","B","C" };
        private void Form1_Load(object sender, EventArgs e)
        {
            FillLstView();
        }
        private void Additem_Click(object sender, EventArgs e)
        {
            listofstring.Add("New Item");
            FillLstView();
        }
        private void RemoveItem_Click(object sender, EventArgs e)
        {
            listofstring.RemoveAt(lstview.FocusedItem.Index);
            EditItem.Enabled = false;
            RemoveItem.Enabled = false;
            FillLstView();
        }
        private void lstview_SelectedIndexChanged(object sender, EventArgs e)
        {
                RemoveItem.Enabled = true;
                EditItem.Enabled = true;
        }
        private void EditItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Edit", "Title", "Edited", 0, 0);
            if (input != "")
            {
                listofstring[lstview.FocusedItem.Index] = input;
                EditItem.Enabled = false;
                RemoveItem.Enabled = false;
                FillLstView();
            }
        }
        private void FillLstView()
        {
            lstview.Clear();
            foreach (var item in listofstring)
            {
                lstview.Items.Add(item);
            }
        }
