            string input = @"
                <root>
                    <slide>
                        <Image>hi</Image>
                        <ImageContent>this</ImageContent>
                        <Thumbnail>is</Thumbnail>
                        <ThumbnailContent>A</ThumbnailContent>
                    </slide>
                </root>";
            XDocument doc = XDocument.Parse(input);
            //You can also load data from file by pasing file path to Load method
            //XDocument doc = XDocument.Load("Data.xml");
            foreach(var slide in doc.Root.Elements("slide"))
            {
                var words = slide.Elements().Select(el => el.Value);
                string s = String.Join(" ", words.ToArray());
            }
