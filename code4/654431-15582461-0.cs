    testText.Text = "Testing 123" + Environment.NewLine + "Testing ABC";
    StringBuilder builder = new StringBuilder();
    builder.Append(Environment.NewLine);
    builder.Append("Test Text");
    builder.Append(Environment.NewLine);
    builder.Append("Test 2 Text");
    testText.Text += builder.ToString();
