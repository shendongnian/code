    string testData = @"<StepList>
                            <Step>
                            <Name>Name1</Name>
                            <Desc>Desc1</Desc>
                            </Step>
                            <Step>
                            <Name>Name2</Name>
                            <Desc>Desc2</Desc>
                            </Step>
                        </StepList>";
    XmlSerializer serializer = new XmlSerializer(typeof(StepList));
    using (TextReader reader = new StringReader(testData))
    {
        StepList result = (StepList) serializer.Deserialize(reader);
    }
