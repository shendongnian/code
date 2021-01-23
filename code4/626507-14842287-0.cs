    int rows = 3;
    int cols = 4;
    List<List<PictureBox>> pictures = new List<List<PictureBox>>();
    for(int r = 0; r < rows; r++)
    {
        List<PictureBox> pList = new List<PictureBox>();
        for(int c = 0; c < cols; c++)
        {
            //do any positioning you need to do here
            pList.Add(new PictureBox());
        }
        pictures.Add(pList);
    }
