    public class IputValidator
    { 
         public event Action ValidationDone;
         private List<TextBox> boxes = new List<TextBox>();
         public void RegisterTextBox(TextBox tb) 
         { 
           tb.TextChanged += (s,e) => Validate;
           boxes.Add(tb);
         }
         public void Validate() 
         { 
            foreach(var t in boxes)
            {
              if(string.IsNullOrEmpty(t.Text)) return;
            }
            //all data inputed. fire validationDone event.
         }
    }
