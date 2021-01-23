    static void Main()
    {
        string xmlString = @"<ArticleDetail xmlns=""http://schemas.datacontract.org/2004/07/EEL.ArticleDatabase.WebService.Model"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Approved>false</Approved><ArticleGroupCode>5304</ArticleGroupCode><ArticleGroupName>Standblenders</ArticleGroupName><ArticleNumber>052ASB2600</ArticleNumber><BrandLogoTypeResourceId/><BrandName>Electrolux</BrandName><Denomination>Köksmaskiner ASB2600 Electrolux</Denomination><Description>Exklusiv mixer i borstat stål som enkelt krossar is, 1,6l glaskanna OBS! Levereras som 2-pack</Description><Documents/><Ean>7319590015596</Ean><Id>1649151</Id><Images/><ModelNumber>ASB2600</ModelNumber><PackageQuantity>1</PackageQuantity><Parameters><Parameter><Category>Dimensioner</Category><DataType>long</DataType><Description/><DisplayName>Bredd</DisplayName><Name>Bredd</Name><Priority>1</Priority><Unit>mm</Unit><Value>290</Value></Parameter><Parameter><Category>Dimensioner</Category><DataType>long</DataType><Description/><DisplayName>Djup</DisplayName><Name>Djup</Name><Priority>2</Priority><Unit>mm</Unit><Value>240</Value></Parameter><Parameter><Category>Dimensioner</Category><DataType>long</DataType><Description/><DisplayName>Höjd</DisplayName><Name>Höjd</Name><Priority>3</Priority><Unit>mm</Unit><Value>380</Value></Parameter></Parameters><Published>false</Published><ReplacedByArticleNumber/><ReplacesArticleNumber/><SellText1>Kraftfull - perfekt för att krossa is.</SellText1><SellText2>Glaskanna som rymmer 1,6 liter, med 6-bladigt knivsystem.</SellText2><SellText3>Väldigt enkel rengöring av kanna och knivsystem</SellText3><SellText4/><SellText5/><StatusCode>0</StatusCode><SupplierArticleNumber>ASB2600</SupplierArticleNumber><SupplierCode>150</SupplierCode><SupplierName>Elon Elkedjan Logistic AB</SupplierName><Texts><TextItem><Text>Test</Text><Type>Short</Type></TextItem><TextItem><Text>Elon</Text><Type>Long</Type></TextItem></Texts></ArticleDetail>";
        var xDoc = XDocument.Parse(xmlString);
        Write(xDoc.Root, 0);
    }
    static void Write(XElement el, int offset)
    {
        Console.Write(new string(' ', offset));
        Console.WriteLine(el.Name.LocalName);
        foreach (var child in el.Elements())
        {
            Write(child, offset + 1);
        }
    }
