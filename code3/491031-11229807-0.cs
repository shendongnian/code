    string enteredText = "";
    char key;
    bool done = false;
    while (!done) 
    {
       key = Console.ReadKey();
       if (key is number)
           enteredText += key;
       else if (key is backspace)
       {
           //remove the last char from enteredText.  Handle case where enteredText has length 0
           Console.Write(backspace); 
       }
       else if ((key is enter) && (enteredText.Length > 0))
           done = true;
       else
       {
           // invalid char.
           //MSDN says the char is echoed to the console so remove it
           Console.Write(backspace);
           //Beep at the user?
       }
    }
