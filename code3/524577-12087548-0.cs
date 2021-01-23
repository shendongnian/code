    string input = @"
        <root>
            <slide>
                <Image>hi</Image>
                <ImageContent>this</ImageContent>
                <Thumbnail>is</Thumbnail>
                <ThumbnailContent>A</ThumbnailContent>
            </slide>
        </root>";
    foreach (XText text in (IEnumerable)XDocument.Parse(input).XPathEvaluate("//*/text()"))
    {
        Console.WriteLine(text.Value);
    }
