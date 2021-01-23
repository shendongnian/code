    string email = "Confirmación@test.com";
    
    string escaped = 
           System.Uri.EscapeDataString(email); // Confirmaci%C3%B3n%40test.com
    string unescaped = 
           System.Uri.UnescapeDataString(email); //Confirmación@test.com
