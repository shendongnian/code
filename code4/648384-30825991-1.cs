    public class Program
    {
      public static void Main()
      {
        try
        {
          string jsonText = @"
          {
            ""food"": {
              ""fruit"": {
                ""apple"": {
                  ""colour"": ""red"",
                  ""size"": ""small""
                },
                ""orange"": {
                  ""colour"": ""orange"",
                  ""size"": ""large""
                }
              }
            }
          }";
          var foodJsonObj = JObject.Parse(jsonText);
          var bananaJson = JObject.Parse(@"{ ""banana"" : { ""colour"": ""yellow"", ""size"": ""medium""}}");
          
          var fruitJObject = foodJsonObj["food"]["fruit"] as JObject;
          fruitJObject.Property("orange").AddAfterSelf(new JProperty("banana", fruitJObject));
          
          Console.WriteLine(foodJsonObj.ToString());
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
        }
      }
    }
