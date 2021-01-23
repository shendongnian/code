    public class RemoveButtons : GetChromeDataProcessor
    {
        public override void Process(GetChromeDataArgs args)
        {
            Assert.ArgumentNotNull(args, “args”);
            Assert.IsNotNull(args.ChromeData, “Chrome Data”);
    
            if (“field”.Equals(args.ChromeType, StringComparison.OrdinalIgnoreCase))
            {
                Field argument = args.CustomData["field"] asField;
                Assert.ArgumentNotNull(argument, “CustomData[\"{0}\"]“.FormatWith(new object[] { “field” }));
    
                if (argument.Name == “Title” && MainUtil.GetBool(argument.Item["NeedsToBeCheckedToPersonalize"], false))
                {
                    args.ChromeData.Commands.RemoveAll(delegate(WebEditButton b)
                                    {
                                        return b.Header == “Personalize”;
                                    });
                }
            }
        }
    }
