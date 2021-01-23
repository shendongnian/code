    public enum PromtType
    {
        Question,
        Information,
        Feedback
    }
    
    public class InputBox
    {
        public static void Show(PromtType type)
        {
            switch(type)
           {
               case PromtType.Question:
               //do question things here
               break;
               case PromtType.Information:
               //do information things here
               break;
               case PromtType.Feedback:
               //do feedback things here
               break;
           }
        }
    }
    
    InputBox.Show(PromtType.Question);
