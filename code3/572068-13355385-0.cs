     public string GetMail(string[] docs, string originalMessage)
     {
            for (int i = 0; i < docs.Length; i++)
                  originalMessage = originalMessage + " " + docs[i];
             
             return originalMessage;
      }
