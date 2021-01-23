    String name;
    //Code....
    for (int i = 0; i < listBox.Items.Count; i++)
        {
         if(name.Equals(listBox.Items[i].Text)){
            listbox.setSelected(i,true);
         }
     }
