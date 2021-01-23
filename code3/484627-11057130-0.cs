    for (int i = 0; i < files.Length; i++) 
    { 
        if(files[i].EndsWith(".xnb"))
        {
            string path = files[i].Substring(BasicUtils.FindsubString(files[i], "Textures")).Replace(".xnb", ""); 
     
            roofTextures.Add(DataCenter.AddTexture(DataCenter.Content.Load<Texture2D>(path))); 
        }
    } 
