    foreach (string number in array_questions)
    {
        //Response.Write(number + " ");
        //Response.Write(Environment.NewLine);
        Response.Write(string.Join(", ", number) + Environment.NewLine);         
    }
