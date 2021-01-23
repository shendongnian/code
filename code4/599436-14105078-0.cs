    TextBox b= null;
    for (int i = 0; i < 4; i++)
    {
          b=new TextBox();
          b.ID="textbox"+i;
          b.Attributes.Add("name",b.ID);
          placeHolder.Controls.Add(b); //placeHolder is the container for all dynamically-added controls
    }
