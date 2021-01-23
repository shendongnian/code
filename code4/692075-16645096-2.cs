    public class TextBoxColumn : ITemplate 
    {
          public void InstantiateIn(Control container)
          {
              var txt = new TextBox();
              txt.Id = "TT";
              container.Controls.Add(txt);
          }
    }
