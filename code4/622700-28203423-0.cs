     public class MyViewModel
     {
         /// <summary>
         /// This is a really dumb hack, because the form post sends "on" / "off"
         /// </summary>                    
         public enum Checkbox
         {
            on = 1,
            off = 0
         }
         public string Name { get; set; }
         public Checkbox Checked { get; set; }
    }
