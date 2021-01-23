    string _message;  
    _message = "this is my long message which needs to be split in to two string after 160 characters. This is a long message. This is a long message. This is a long message. This is a long message. This is a long message.";  
    string message1 = _message.Substring(0,160);  
    string message2 = _message.Substring(161,_message.Length-161);
  
