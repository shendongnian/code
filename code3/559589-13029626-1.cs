    public class ButtonData
    {
       public ButtonData(string text, string image, BorderStyle border)
       {
           Text = text;
           Image = image;
           Border = border;
       }
    
       public string Text { get; private set; }
       public string Image { get; private set; }
       public BorderStyle Border { get; private set; }
    }
    var devMenuData = new List<ButtonData> { 
                                      new ButtonData("", null, "Borderstyle.None"), 
                                      new ButtonData("text submenu 3 button 1",
                                                     "Settings.png",
                                                     Borderstyle.FixedSingle), 
                                      ...
                                           };
    private void CreateButtons(IEnumerable<ButtonData> data)
    {
        foreach (var buttonData in data)
        {
            SubBtnText[i].Text = buttonData.Text;
            pictureBoxSubBtn[i].Image = Image.FromFile(buttonData.Image);
            panelSubBtn[i].BorderStyle = buttonData.Border;
        }
    }
