    Here what I did for "btnPrevImage" is some how easier:
    *// this button is forward button* 
    private void btnForward_Click(object sender, EventArgs e)
        {
            if(currentIndex!=imageList1.Images.Count-1 && imageList1.Images.Count > 0)
            {
                pictureBox1.Image = imageList1.Images[currentIndex++];
            }
            
        }
    *// this button is for Previews button*  
    private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (currentIndex!=0)
            {
                pictureBox1.Image = imageList1.Images[--currentIndex];
            }
      
    do not forget to declare currentIndex.
