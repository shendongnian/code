    string suggestedFileName;   
    string dispositionString = response.GetResponseHeader("Content-Disposition");
                
        if (dispositionString.StartsWith("attachment")) {
              System.Net.Http.Headers.ContentDispositionHeaderValue contentDisposition = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(dispositionString);
              if (!string.IsNullOrEmpty(contentDisposition.FileNameStar))
              {
                  suggestedFileName = contentDisposition.FileNameStar;
              }
              else
              {
                   suggestedFileName = contentDisposition.FileName.Trim('"');
              }
                  
             }
