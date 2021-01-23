    int numberOfProperties = 15;
    IList<string> code = new List<string>();
    code.Add("public static class MyTestClass");
    code.Add("{");
    for (int i = 0; i < numberOfProperties; i++)
    {
	    code.Add("public static string MyTestProperty" + i);
        code.Add("{");
        code.Add("get");
        code.Add("{");
        code.Add("return \"My test\" + i + "";");
        code.Add("}");
        code.Add("}");
    }
    code.Add("}");
    File.AppendAllLines(<path>, code);
