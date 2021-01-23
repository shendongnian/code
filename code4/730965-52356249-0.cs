    private static MainDocumentPart AddHeader(MainDocumentPart mainDocPart)
            {
                string LogoFilename = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images/TemplateLogo.png");     
                mainDocPart.DeleteParts(mainDocPart.HeaderParts);
                var FirstHeaderPart = mainDocPart.AddNewPart<HeaderPart>();
                var DefaultHeaderPart = mainDocPart.AddNewPart<HeaderPart>();
                var imgPartFirst = FirstHeaderPart.AddImagePart(ImagePartType.Jpeg);           
                var imagePartFirstID = FirstHeaderPart.GetIdOfPart(imgPartFirst);
                var imgPartDefault = FirstHeaderPart.AddImagePart(ImagePartType.Jpeg);
                var imagePartDefaultID = FirstHeaderPart.GetIdOfPart(imgPartDefault);
                using (FileStream fs = new FileStream(LogoFilename, FileMode.Open))
                {
                    imgPartFirst.FeedData(fs);                
                }
                using (FileStream fsD = new FileStream(LogoFilename, FileMode.Open))
                {
                    imgPartDefault.FeedData(fsD);
                }
                var rIdFirst = mainDocPart.GetIdOfPart(FirstHeaderPart);
                var FirstHeaderRef = new HeaderReference { Id = rIdFirst, Type = HeaderFooterValues.First };
                var rIdDefault = mainDocPart.GetIdOfPart(DefaultHeaderPart);
                var DefaultHeaderRef = new HeaderReference { Id = rIdDefault };
    
                var sectionProps = mainDocPart.Document.Body.Elements<SectionProperties>().LastOrDefault();
                if (sectionProps == null)
                {
                    sectionProps = new SectionProperties();
                    mainDocPart.Document.Body.Append(sectionProps);
                }
                sectionProps.RemoveAllChildren<HeaderReference>();        
                FirstHeaderPart.Header = GenerateFirstPicHeader(imagePartFirstID);
                DefaultHeaderPart.Header = GeneratePicHeader(imagePartDefaultID);
                FirstHeaderPart.Header.Save();
                DefaultHeaderPart.Header.Save();
                sectionProps.PrependChild(new TitlePage());
                
                sectionProps.AppendChild(DefaultHeaderRef);
                sectionProps.AppendChild(FirstHeaderRef);
    
                return mainDocPart;
            }
