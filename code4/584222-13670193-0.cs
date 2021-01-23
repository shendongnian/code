            double a = Convert.ToDouble(textBox1.Text); // Tip: I would recomment using Double.TryParse() instead of what you have here unless you know a number will always be in this box (I will provide an example with your 'z')
            double b = Convert.ToDouble(textBox2.Text); // Tip: I would recomment using Double.TryParse() instead of what you have here unless you know a number will always be in this box (I will provide an example with your 'z')
            /* double z = Convert.ToDouble(label1.Text);  /* First off, you need to correct your syntax errors:
                                                        * You had: double z - Convert.toDouble(label1.Text);   Notice the minus (-) and not equal (=) sign
                                                        *  You also need to capatilize the 'T' in what you have 'toDouble' and change it to 'ToDouble' 
                                                        *  Second off, you need to correct your runtime errors:
                                                        *  In this line, you are trying to convert something in this label (lbl1) to a double.  This will not work because at 
                                                        *  runtime, there is nothing in this label because it has no text. Incase you don't know, if you are using Visual Studio, you should 
                                                        *  put a break point on this line by pressing F9.  Then when you run your application, Visual Studio will halt/pause here so you can see 
                                                        *  value of label1.Text by moving your mouse over it.  You will notice it is "" which cannot be converted 
                                                        *  There are a few possible solutions that you can emply to make this work but I will show you my prefered method below: */
            double z;
            bool didItParseDouble = Double.TryParse(label1.Text, out z); /* The first paramater is what you want to try and parse.. in this case, you are trying to parse a label.
                                                  * If it can parse it, it will assign the value to the out parameter which is 'z'  You must preceed this with the out keyword!
                                                   * If it can't parse, it will */
            if (didItParseDouble)
            {
                // It parsed/convered (although parse and convert are technically different)
                // When you first run the application, you will NOT hit this block of code because ditItParse is false because label1.Text is "".  (Put a break point here and you will see)
                // This is where you should put your calcuations at.  Don't forget, though, that if the user enters nothing for the first or second textbox, your code as is will fail so you should do a try parse there as well!
                // There are many ways to handle this, various patters, this is just one.  You can even put the Double.TryParse(...) in the if conditional statement!
            }
            else
            {
                // It couldn't parse so you could put some error handling here if you would like.
            }
            
            label1.Text = (a + b).ToString(); // C# is case sensitive so your code won't compile!  You had:  label1.TexT = (a + b).ToString(); 
            label2.Text = ( z + a).ToString(); // Now that z is a valid double it should work.    //not ok and get error  
