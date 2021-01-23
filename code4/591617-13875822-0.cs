    //Initialize a string of name HTML as our HTML code
    string HTML = "<p><span style=\"text-decoration: underline; color: #ff0000;\"><strong>para1</strong></span></p> <p style=\"text-align: center;\"><strong><span style=\"color: #008000;\">para2</span> स्द्स्द्सद्स्द para2 again<br /></strong></p> <p style=\"text-align: left;\"><strong><span style=\"color: #0000ff;\">para3</span><br /></strong></p>";
    //Initialize a string array of name strSplit to split HTML with </p>
    string[] strSplit = HTML.Split(new string[] { "</p>" }, StringSplitOptions.None);
    //Initialize a string of name expectedOutput
    string expectedOutput = "";
    //Initialize i as an int. Continue if i is less than strSplit.Length. Increment i by 1 each time you continue
    for (int i = 0; i < strSplit.Length; i++)
    {
        //Append strSplit[i] to expectedOutput
        expectedOutput += strSplit[i];
    }
    //Append </p> at the end of the string
    expectedOutput += "</p>";
    //Write the output to the Console
    Console.WriteLine(expectedOutput);
    Console.Read();
