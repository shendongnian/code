    static void Main(string[] args)
            {            
                XDocument xmlSkuDescDoc = XDocument.Parse
                    (@"<root>
                                    <slide>
                                    <Image>hi</Image>
                                    <ImageContent>this</ImageContent>
                                    <Thumbnail>is</Thumbnail>
                                    <ThumbnailContent>A</ThumbnailContent>
                                    </slide>
                                    </root> "
                    ); 
                 var result = (from data in xmlSkuDescDoc.Descendants("slide")
                 select data).Elements().Select(i => i.Value).Aggregate((a, b) => a + " " + b); 
                Console.ReadKey();
            }
