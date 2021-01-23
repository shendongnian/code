    StringBuilder mystring = new StringBuilder(@"Hey this is a fairly long string which I used in this /
    example to show how long strings might be broken up into different lines based on how  /
    wide your text area is. What is going to happen is we are about to insert a newline  /
    after however many characters the textarea is wide. We'll also count the number of   /
    newlines that we put in, and that number plus one will be the number we need for the  /
    textarea!");
    
    int columnCounter = 0;
    int lineCounter= 1; //1 for the first line
    const int COLUMNS_IN_TEXT_AREA = howeverManyColsYouHave;
    for(int i = 0; i<mystring.Length;i++) //set to less than mystring.length, just in case the string were really short.
    {
        if(columnCounter >= COLUMNS_IN_TEXTAREA)
        {
            mystring.Insert(i,"\n");
            lineCounter ++;
        }
    }
