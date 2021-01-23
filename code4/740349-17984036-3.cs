    private void button2_Click(object sender, EventArgs e)
    {
        // This example is using the Tag property as an index
        // keep in mind that the index will be one less than your 
        // total number of Pictureboxes also make sure that your 
        // array is sized correctly. 
        var places = new PictureBox[100]; // I used 10 as a test
        int index;
        foreach (var item in Controls )
        {
            if (item is PictureBox)
            {
                PictureBox pb = (PictureBox)item;
                if (int.TryParse(pb.Tag.ToString(), out index))
                {
                    places[index] = pb;
                }
            }
        }
     }
