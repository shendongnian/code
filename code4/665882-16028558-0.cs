    // using
    using Newtonsoft.Json.Linq;
    string JSarray_1 = @"[[""string 1"", 2013, ""string 2""], ""string 3"", [""string 4"", , ""string 5""]]";
    JObject j = JObject.Parse("{\"j\":" + JSarray_1 + "}");
    MessageBox.Show((string)j["j"][0][2]); // "string 2"
