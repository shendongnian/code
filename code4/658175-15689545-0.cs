    if (listBox2.Items.Count > 0)
    {
        for (int i = 0; i < listBox2.Items.Count; i++)
        {
            if (listBox2.GetSelected(i) == true)
            {
                Foods m = chosenBox.SelectedItem as Foods;
                list.Remove(m);
            }
        }
    }
    listBox1.Items.Add(listBox2.SelectedItem);
    listBox2.Items.Remove(listBox2.SelectedItem);
