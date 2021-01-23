    private List<Button> addButton()
    {
        List<Button> buttonList = new List<Button>();
        buttonList.Add(button1);
        buttonList.Add(button2);
        buttonList.Add(button3);
        buttonList.Add(button4);
        buttonList.Add(button5);
        buttonList.Add(button6);
        buttonList.Add(button7);
        buttonList.Add(button8);
        buttonList.Add(button9); 
  
        return buttonList;
    }
    private void button1_Click(object sender, EventArgs e)
    {
         foreach (var button in addButton())
         {
              button.Enabled = false;
         }
    }
