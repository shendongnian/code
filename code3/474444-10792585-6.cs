    private void button1_Click(object sender, EventArgs e)
    {
        Form2 edit = new Form2();
        edit.SaveEvent += new Form2.SaveEventHandler(edit_SaveEvent);  //Add event handler
        edit.name = People[this.listView1.SelectedItems[0].Index].Name;
        edit.age = People[this.listView1.SelectedItems[0].Index].Age;
        edit.ShowDialog(this);
    }
    void edit_SaveEvent(object sender, SaveEventArgs e)
    {
        //Do Your work here with e.newAge and e.newName
        ((Form2)sender).Close(); //Close Form2
    }
