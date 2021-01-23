    TextBox b= null;
    for (int i = 0; i < 4; i++)
    {
          b=new TextBox();
          b.ID="textbox"+i;
          //asp.net will assign the name the same as the ID of the element
          placeHolder.Controls.Add(b); //placeHolder is the container for all dynamically-added controls
    }
