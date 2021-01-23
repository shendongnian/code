    private void btnBefore_Click(object sender, EventArgs e)
    {
        --pCurrentImage;
        if (imageFiles.Length > 0)
        {
            pCurrentImage = pCurrentImage < 0 ? imageFiles.Length - 1 : pCurrentImage;
            ShowCurrentImage();
        }
    }       
     private void btnNext_Click(object sender, EventArgs e)
            {
                ++pCurrentImage;
                if (imageFiles.Length > 0)
                {
                    pCurrentImage = pCurrentImage >= imageFiles.Length ? 0 : pCurrentImage;
                    ShowCurrentImage();
                }
            }
