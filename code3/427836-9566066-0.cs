    var pictures = new List<PictureBox>();
    pictures.Add(pic1);
    pictures.Add(pic2);
    //...
    
    
    for (int i = 0; i < 10; i++)
    {
         if (Textbox.Text[i].ToString() == "1") 
              pictures[i].Tag = "cb.png";
    }
