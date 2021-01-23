    //On the sender side
    byte[] bytesA = Encoding.Default.GetBytes(A);
    byte[] bytesB = Encoding.Default.GetBytes(B);
    string encA = Convert.ToBase64String(bytesA);
    string encB = Convert.ToBase64String(bytesB);
    
    string C = encA + "|" + encB;
    
    //On the receiver side
    string[] parts = C.Split('|');
    string A = Encoding.Default.GetString(Convert.FromBase64String(parts[0]));
    string B = Encoding.Default.GetString(Convert.FromBase64String(parts[1]));
