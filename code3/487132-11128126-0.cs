    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curve curItem = null;
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                curItem = (Curve)listBox1.SelectedItems[i];
                if (curItem != null)
                {
                    int index = listBox1.Items.IndexOf(curItem);
                    if (curItem.newName == null)
                    {
                        listBox1.SetSelected(index, false);
                    }
                }
            }
        }
