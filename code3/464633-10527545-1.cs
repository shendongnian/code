        try
            {
                if (!string.IsNullOrWhiteSpace(selectedstory.Slug))
                {
                    if (File.Exists(pathToImage))
                    {
                        string SlugName = selectedstory.Slug;
                        if (pathToImage.Contains(SlugName))
                        {
                            
                        }
                        else
                        {
                            this.dialog.ShowError("Image file name is not same as Slug name", null);
                        }
                    }
                    else
                    {
                        this.dialog.ShowError("Image file does not exist at the specified location", null);
                    }
                }
              }
            catch (Exception ex)
            {
                this.dialog.ShowError("Slug is Empty,please enter the Slug name", null);
                
            }
        }
