    Picturebox pic = new Picturebox();
    foreach(Control picturebox in Form1){
       if (pic.Bounds.IntersectsWith(picturebox.Bounds))
       {
           //We have a problem, Houston, because we just collided!
       }
    }
