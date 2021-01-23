        [Test]
        public void IterateThruImages()
        {
            WorkbookPart wbPart = document.WorkbookPart;
            var workSheet = wbPart.WorksheetParts.FirstOrDefault();
            foreach (ImagePart i in workSheet.DrawingsPart.ImageParts)
            {
                var rId = workSheet.DrawingsPart.GetIdOfPart(i);
                Stream stream = i.GetStream();
                long length = stream.Length;
                byte[] byteStream = new byte[length];
                stream.Read(byteStream, 0, (int)length);
                var imageAsString = Convert.ToBase64String(byteStream);
                Console.WriteLine("The rId of this Image is '{0}'",rId);
            }
        }
        [Test]
        public void GetImageRelationshipIdAndImageOfThatId()
        {
            string row = "1";
            string col = "0";
            WorkbookPart wbPart = document.WorkbookPart;
            var workSheet = wbPart.WorksheetParts.FirstOrDefault();
            TwoCellAnchor cellHoldingPicture = workSheet.DrawingsPart.WorksheetDrawing.OfType<TwoCellAnchor>()
                 .Where(c => c.FromMarker.RowId.Text == row && c.FromMarker.ColumnId.Text == col).FirstOrDefault();
            var picture = cellHoldingPicture.OfType<DocumentFormat.OpenXml.Drawing.Spreadsheet.Picture>().FirstOrDefault();
            string rIdofPicture = picture.BlipFill.Blip.Embed;
            Console.WriteLine("The rID of this Anchor's [{0},{1}] Picture is '{2}'" ,row,col, rIdofPicture);
            ImagePart imageInThisCell = (ImagePart)workSheet.DrawingsPart.GetPartById(rIdofPicture);
        }
