    app .Application.Quit();
    Add teh above line code in your code in following way:
    object misValue = System.Reflection.Missing.Value;
    workbook.Close(true, misValue, misValue);
    app .Application.Quit();
    app.Quit();
