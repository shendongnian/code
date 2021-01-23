    using System.Drawing;
    
        private bool IsValidImageFile(IFormFile file) {
        
          try {
            var isValidImage = Image.FromStream(file.OpenReadStream());
          } catch {
            return false;
          }
        
          return true;
        }
