    public class MyTextBox : TextBox, ISupportInitialize
    {
         ...
         public string DbColumn { get; set; }
         public void BeginInit() { }
         public void EndInit()
         {
             bool duplicatesFound = Parent.Controls
                 .OfType<MyTextBox>()
                 .GroupBy(mtb => mtb.DbColumn)
                 .Any(x => x.Count() > 1);
             if (duplicatesFound)
                 throw InvalidOperationException("MyTextBoxes with duplicate DbColumn property found."); 
         }
    }
