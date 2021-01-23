    private string getNextImage()
    {
        if(index < paths.Count - 1)
        {
            index += 1;
        }
        else
        {
            index = 0;
        }
        return paths[index];   
    }
