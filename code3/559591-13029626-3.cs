    private void CreateButtons(IEnumerable<ButtonData> data)
    {
        foreach (var buttonData in data)
        {
            SubBtnText[i].Text = buttonData.Text;
            pictureBoxSubBtn[i].Image = Image.FromFile(buttonData.Image);
            panelSubBtn[i].BorderStyle = buttonData.Border;
        }
    }
