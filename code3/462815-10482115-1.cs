    private void prevImage()
    {
        if(selected == 0)
        {
            selected = folderFile.Length - 1;
            showImage(folderFile[selected]); 
        }
        else
        {
            selected = selected - 1; showImage(folderFile[selected]);
        }
    }
    
    private void nextImage()
    {
        if(selected == folderFile.Length - 1)
        {
            selected = 0; 
            showImage(folderFile[selected]);
        }
        else
        {
            selected = selected + 1; showImage(folderFile[selected]);
        }
    }
