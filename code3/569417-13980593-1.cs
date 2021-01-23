    public class One
    {
    
        // declared:
        private.some.Reference.ToSomeClass _container;
    
        One(ToSomeClass container)
        {
              _container = container;
        }
    
        private void button_click(object sender, EventArgs e)
        {
              if(_container != null)
              {
                   _container.Name = textbox.Text (or some other component)
              }
        }
    }
