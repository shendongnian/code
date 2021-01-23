    using System.Text.RegularExpressions;
  
    string input = "foo-bar----baz--biz";
    Regex regex = new Regex("\\-+");
    string output = regex.Replace(input, "-");
