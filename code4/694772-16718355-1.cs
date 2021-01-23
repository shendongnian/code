    string testString = @"       
                         public class MyClass
                         {
                             private bool MyMethod(string s)
                             {
                                 return s == "";
                             }
                         }";
        
    string[] lines = testString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    string[] unindentedArray = UnindentAsMuchAsPossible(lines).ToArray();
