     public class MovieSelectionNotFoundException : Exception
     {
         public MovieSelectionNotFoundException()
         {
         }
    
         public MovieSelectionNotFoundException(string message)
             : base(message)
         {
         }
    
         public MovieSelectionNotFoundException(string message, Exception inner)
             : base(message, inner)
         {
         }
     }
