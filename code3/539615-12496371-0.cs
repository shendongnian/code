    I would first use just one event handler for the buttons, It would look like this:
    
     protected void ButtonClick(object sender, EventArgs e)
            {
                Button clickedButton = (Button) sender;
                string selectedId = clickedButton.ID;
                string[] idParameters = selectedId.Split('_');
                string textBoxId = "textbox" + idParameters[1];
                dailogueOpen(textBoxId);
            }
    
    What I did here is use a pattern for the names of the textboxes, so for instance if you have buttons with Ids like: button_1,button_2,...,button_n, you can infer what the corresponding textbox is. 
    If you click button_1, by spliting its id you'll know that its corresponding textbox is the one whose id is textbox1.
    
    Then the dialogueOpen function would look like this:
    
    private void dailogueOpen(String textBoxId)
    {
       if (listBox1.SelectedItem == null)
       {
          MessageBox.Show("Please Select a form");
        }
       else
       {
          var selectedItem = (FormItems)listBox1.SelectedItem;
          var form2result = new Form2(myDataSet, selectedItem);
          var resulOfForm2 = form2result.ShowDialog();
          if (resulOfForm2 == DialogResult.OK)
          {
              TextBox textBox = (TextBox)         this.Form.FindControl("MainContent").FindControl(textBoxId);
              textBox.Text = resulOfForm2.getValue();
          }
       }
     }
    
    Where MainContent is the id of container where the textboxes are.
    
    All in all:
    - I would use a pattern for button and texboxes id.
    - According to the button being clicked I infer its corresponding texbox id.
    - Then  find the texbox and update its value.
