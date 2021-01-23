    private void RestartToFrameIndex(int index){
       pictureBox.Image.SelectActiveFrame(new FrameDimension(pictureBox.Image.FrameDimensionsList[0]), index);
       pictureBox.Image = pictureBox.Image;
    }
    //If you want to restart to the first frame, just call the method above like this:
    RestartToFrameIndex(0);
