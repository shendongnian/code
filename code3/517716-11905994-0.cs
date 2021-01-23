    public void do_something( myFunctions action, String information)
    {
       int input1;
       int input2;
       /*
         Lets say the string was.... the dimensions of a rectangle expressed as 5x8
         here we parse the string so...
         information is "5x8:
         set input1 to 5
         set input2 to 8
       */
       //then run the function that was passed in.
       action(input1, input2);
    }
