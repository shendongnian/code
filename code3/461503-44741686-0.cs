    // required using directives
    using System;
    using System.Collections;
    String      inputString = "The lazy fox couldn't jump, poor fox!";
    ArrayList   locations   =  new ArrayList();      // array for found indexes
    string[] lineArray = inputString.Split(' ');     // inputString to array of strings separated by spaces
    int tempInt = 0;
    foreach (string element in lineArray)
    {
         if (element == "fox")
         {
             locations.Add(tempInt);   // tempInt will be the index of current found index and added to Arraylist for further processing 
         }
     tempInt++;
    }
