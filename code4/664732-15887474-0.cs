    const string value = "aa2b";
    var result = "";
    for (var i = 0; i < value.Length; i++)
    {
         int num;
         if (Int32.TryParse(value.Substring(i, 1), out num))
         {
             for (var j = 0; j < num; j++)
             {
                result += value.Substring(i + 1, 1);
             }
                i++;
         }
         else
         {
             result += value.Substring(i, 1);
         }
    }
    
    textBox1.AppendText("woord:" + result);
