    private void buttonDelete_Click(object sender, EventArgs e){
        for (int i = listView1.SelectedIndices.Count - 1; i >= 0; i--)                
             listView1.Items.RemoveAt(listView1.SelectedIndices[i]);
    }
    
