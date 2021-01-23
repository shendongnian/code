    List<string> lMyImages = new List<string>();
    StringBuilder sRenderOnMe = new StringBuilder();
    
    foreach(var OneImg in lMyImages)
       sRenderOnMe.AppendFormat("<li><img src=\"{0}\"></li>", OneImg);
    
    OneLiteral.Text = sRenderOnMe.ToString():
