    public static HelperResult Container(int containerSize, Func<dynamic, HelperResult> template)
    {
        return new HelperResult(writer => template(null).WriteTo(writer));
    }
    @Html.Container(24, @<span>hello world... and other content here</span>)
