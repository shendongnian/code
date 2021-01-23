    POPClient poppy = new POPClient();
    poppy.Connect("pop.gmail.com", 995, true);
    poppy.Authenticate(username@gmail.com, "password");
    int Count = poppy.GetMessageCount();
    if (Count > 0)
    {
       for (int i = Count; i >= 1; i -= 1)
       {
         OpenPOP.MIMEParser.Message m = poppy.GetMessage(i, false);
         //use the parsed mail in variable 'm'
       }
    }
