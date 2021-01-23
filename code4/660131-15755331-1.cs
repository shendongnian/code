    private void myForm_MouseClick(object sender, MouseEventArgs e)
    {
       Control ctrl = Control.GetChildAtPoint(e.Location);
       if (ctrl != null)
       {
          // do something with the clicked control
       }
       else
       {
          // if ctrl is null, then the parent form itself was clicked,
          // rather than one of its child controls
      }
    }
    
