    private void MyMethod(List<PictureBox> pictureBoxes)
    {
        foreach (var pictureBox in pictureBoxes)
        {
            var user = ReturnUser(pictureBox);
            if (user != null)
            {
                 usersFirstRow.Add(user);
                 // This line not needed: user = null; 
            }
        }
    }
    List<PictureBox> pictureBoxes = 
        new List<PictureBox>() { pictureBoxUpOne, pictureBoxUpTwo }
    MyMethod(pictureBoxes);
