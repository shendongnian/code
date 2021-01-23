    const string Callme = "call me";
    var text = e.Result.Text;
    
    switch (text)
       {
       case "test":
           writeConsolas("What do you want me to test?", me);
       break;
       case "change username":
           writeConsolas("What do you want to be called?", me);
       break;
       case "exit":
           writeConsolas("Do you wish me to exit?", me);
       break;
                    
       }
       if (text.StartsWith(CallMe)
           userName = text.Replace(CallMe, string.Empty).Trim();
