     public class LibraryRequestViewModel  {
         private LibraryRequest request;
         public LibraryRequestViewModel(LibraryRequest request){
              this.request = request;
         }
         [Required]
         public string Password {
             get { return this.request.Password; }
             set { this.request.Password = value; }
         }
         // do this for all fields you need
      }
          
