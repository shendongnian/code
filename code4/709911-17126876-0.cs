    public class User
    {
           public string Name { get; set; }
           public string LastName { get; set; }
           public int ID { get; set; }
           public override string ToString()
           {
                 return Name + " " + LastName;
           }
           ...
    }
        
    //fill the listBox
    foreach(User u in listUsers)
    {
           listbox.Items.Add(u);
    }
        
    //get the celected User
        
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
           ListBox lb = (ListBox)sender;
           User user = (User)lb.Items[lb.SelectedIndex];
           MessageBox.Show(user.ID.ToString());
    }
