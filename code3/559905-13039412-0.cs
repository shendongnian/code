    public void Test()
    {
        //C# object which will be accessed by javascript
        var csharpObj = new MyCSharpObject();
        //Create Javascript object
        Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));
        dynamic obj = Activator.CreateInstance(scriptType, false);
        obj.Language = "Javascript";
        obj.AddObject("csharp", csharpObj);
            
        //Load Html (your string in question)
        string html = @"<script type=""text/javascript"">wr(""<span>maddog"");wr(""@"");wr(""website-url.com</span>"")</script>";
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        //Create "wr" function
        string script = "function wr(s){csharp.wr(s);}";
        //Get the text of script tag                
        script += doc.DocumentNode.SelectSingleNode("//script").InnerText;
        //Execute script
        obj.Eval(script);
        //Load the string created by javascript execution
        doc.LoadHtml(csharpObj.Output);
        //tada.....
        var eMailAddress = doc.DocumentNode.InnerText;
        Console.WriteLine(eMailAddress);
    }
    [ComVisible(true)]
    public class MyCSharpObject
    {
        public string Output = "";
        public void wr(string s)
        {
            Output += s;
        }
    }
