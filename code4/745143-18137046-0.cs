    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExcelBuilder obj = new ExcelBuilder();
            obj.SetDataSource(GetTable());
            obj.CreatePackage(@"output.xlsx");
            System.Diagnostics.Process.Start("output.xlsx");
        }
        /// <summary>
        /// Get the DataTable instance
        /// </summary>
        /// <returns>Returns the DataTable instance</returns>
        private DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Image", typeof(Image));
           
            table.Rows.Add("AAAA", GetImageFrom64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAFqSURBVDhPY/hPAph45sP/xs0XoDwIIMqA2v0v/kfu/PA//tTP/ylLTkBFIQCvARk7X/0P2/3pv8/O7/9ddv4E47jV56CyEIDVgL6jL/4nHP3533f/z/+OQE12G96DbS5fe4I4AyYdfwHW7Lz8wf+OragagpachrIgAKsBzUfe/k9dchzKQwUesw5BWRCA1YDKw+//N607DOWhAqIMqAG6oHz5ASgPFXhOJ8KA8kPv/5cu3gXl/f8/9eTz/26rHvxXmffkv8/kvVBRCMDpgry5m6G8//+1lz7+L9x/7T9f553/rj0Ig0EAqwFh24FeWLAVzC49+uk/b9eV/7xNZ8EGlM3bCRaHARQDbDa+/q+24uV/2RUf/rcs3wMV/f+fr/rIf5G6o/8TJ26BiiAA3ADP9U//S8979F9s4rX/wjOe/W9fdRAqgx/ADbCfexmsUWjCQ7BtxAIULyTP2Pk/eyaqHwkBrIFIPPj/HwAXQanDAoJm4wAAAABJRU5ErkJggg=="));
            table.Rows.Add("BBBB", GetImageFrom64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAEoSURBVDhPjZM9S8NQFIb9VcUf4NRNRHCxW4sOji4GK8UspRAIghAEBR0yBSczlSKiEiS0XRR0iODg4H+Q17zn3AZDc68+cLlfnOfkHG5W4CBNU7OyYxUkSQLP82R2YRVEUYSbu1zmIAjM6TJWQetojNXBRIbv++Z0Gatg7fILZy9A7/pTSrHhFIxmQCcu6oL3E+BtZDZ/CI5zYOPitfkL7rvAw55bcJBpL8IwNKe/KIMx2fyfoBEK0naD4Glf6qwJWDPHtA/ku2XmLclOKsH380Av8g4w36kLHrf1jllnQxOhqKC4EoFI2JwyEwVsoLUEgwrKIAmeH8qW8AnzX3C9QqKC2/WqpgVZllUSFyr4OFdJcSrbBXEcm5WdqokCO80us2kUcjgBfgCofKZ+pmmmjQAAAABJRU5ErkJggg=="));
            table.Rows.Add("CCCC", GetImageFrom64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAEUSURBVDhPpZIhc4QwFIQzESdO9gdW9gecrEAgEAgEAoFEIJAIJALJD6hAIBAIBAKBQNw2SydMgNzN3FV8mUne7ibvgSiKAmVZoqoq1HW9wT3PWc/zHFmWIUkSxHGMKIoQBAF838caME0T5nm2wppmHMeVYRhWtgAKl2U58ShkF8DnHQNCeVnRIXp/DGAbgr2ZZk8J79cPK6ydAtI03QV88yZ5tcLaqQVO1mzhpkQ/D2DtFMDPwt70wL6kRKmENljT5i0gDMPdlD+V6Bna3Pc9PM+DYAqfZYZoeK4xb6a56zq4rgvBxRSamKajuW1bOI4DwcUmPEKjaW6a5i+A023ehF5hm/YriEwt/0Hw9+QP8g6uvOAX9G/HbwDThCwAAAAASUVORK5CYII="));
            return table;
        }
        /// <summary>
        /// Converts the From64 data into Image instance
        /// </summary>
        /// <param name="base64String">Image stream in Base64 encoding</param>
        /// <returns>Returns the Image instance</returns>
        private Image GetImageFrom64(string base64String)
        {
            MemoryStream stream = new MemoryStream(System.Convert.FromBase64String(base64String));
            return Image.FromStream(stream);
        }
    }
    public class ExcelBuilder
    {
        /// <summary>
        /// static field to maintain the track the relationship id
        /// </summary>
        private static int s_rId;
        /// <summary>
        /// Field for Data source
        /// </summary>
        private DataTable m_table;
        /// <summary>
        /// Collection to maintain string value of cell and to serialize the content in SharedString xml part
        /// </summary>
        private List<string> sharedStrings = new List<string>();
        /// <summary>
        /// Collection to maintain the image collection added into the excel workbook
        /// </summary>
        private Dictionary<string, Image> ImageCollection = new Dictionary<string, Image>();
        /// <summary>
        /// Set the DataSource of the Excel builder
        /// </summary>
        /// <param name="table"></param>
        public void SetDataSource(DataTable table)
        {
            m_table = table;
        }
        /// <summary>
        /// Create a new Excel file
        /// </summary>
        /// <param name="filePath">Path of the output file</param>
        public void CreatePackage(string filePath)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                CreateParts(package);
            }
        }
        // Adds child parts and generates content of the specified part.
        private void CreateParts(SpreadsheetDocument workbook)
        {
            WorkbookPart workbookPart1 = workbook.AddWorkbookPart();
            GenerateWorkbookPart1Content(workbookPart1);
            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>(GetNextRelationShipId());
            GenerateWorksheetPart1Content(worksheetPart1);
            SharedStringTablePart sharedStringTablePart1 = workbookPart1.AddNewPart<SharedStringTablePart>(GetNextRelationShipId());
            GenerateSharedStringTablePart1Content(sharedStringTablePart1);
        }
        // Generates content of workbookPart1.
        private void GenerateWorkbookPart1Content(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x15" } };
            workbook1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            workbook1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            workbook1.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "Sheet1", SheetId = (UInt32Value)1U, Id = "rId1" };
            sheets1.Append(sheet1);
            workbook1.Append(sheets1);
            workbookPart1.Workbook = workbook1;
        }
        // Generates content of worksheetPart1.
        private void GenerateWorksheetPart1Content(WorksheetPart worksheetPart1)
        {
            Worksheet worksheet1 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            SheetData sheetData1 = new SheetData();
            string drawingrID = GetNextRelationShipId();
            AppendSheetData(sheetData1, worksheetPart1, drawingrID);
            worksheet1.Append(sheetData1);
            if (worksheetPart1.DrawingsPart != null && worksheetPart1.DrawingsPart.WorksheetDrawing != null)
            {
                Drawing drawing1 = new Drawing() { Id = drawingrID };
                worksheet1.Append(drawing1);
            }
            worksheetPart1.Worksheet = worksheet1;
        }
        private void AppendSheetData(SheetData sheetData1, WorksheetPart worksheetPart, string drawingrID)
        {
            for (int rowIndex = 0; rowIndex < m_table.Rows.Count; rowIndex++)
            {
                Row row = new Row() { RowIndex = (UInt32Value)(rowIndex + 1U) };
                DataRow tableRow = m_table.Rows[rowIndex];
                for (int colIndex = 0; colIndex < tableRow.ItemArray.Length; colIndex++)
                {
                    Cell cell = new Cell();
                    CellValue cellValue = new CellValue();
                    object data = tableRow.ItemArray[colIndex];
                    if (data is int || data is float || data is double)
                    {
                        cellValue.Text = data.ToString();
                        cell.Append(cellValue);
                    }
                    else if (data is string)
                    {
                        cell.DataType = CellValues.SharedString;
                        string text = data.ToString();
                        if (!sharedStrings.Contains(text))
                            sharedStrings.Add(text);
                        cellValue.Text = sharedStrings.IndexOf(text).ToString();
                        cell.Append(cellValue);
                    }
                    else if (data is Image)
                    {
                        DrawingsPart drawingsPart = null;
                        Xdr.WorksheetDrawing worksheetDrawing = null;
                        if (worksheetPart.DrawingsPart == null)
                        {
                            drawingsPart = worksheetPart.AddNewPart<DrawingsPart>(drawingrID);
                            worksheetDrawing = new Xdr.WorksheetDrawing();
                            worksheetDrawing.AddNamespaceDeclaration("xdr", "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing");
                            worksheetDrawing.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
                            drawingsPart.WorksheetDrawing = worksheetDrawing;
                        }
                        else if (worksheetPart.DrawingsPart != null && worksheetPart.DrawingsPart.WorksheetDrawing != null)
                        {
                            drawingsPart = worksheetPart.DrawingsPart;
                            worksheetDrawing = worksheetPart.DrawingsPart.WorksheetDrawing;
                        }
                        string imagerId = GetNextRelationShipId();
                        Xdr.TwoCellAnchor cellAnchor = AddTwoCellAnchor(rowIndex, 1, rowIndex, 1, imagerId);
                        worksheetDrawing.Append(cellAnchor);
                        ImagePart imagePart = drawingsPart.AddNewPart<ImagePart>("image/png", imagerId);
                        GenerateImagePartContent(imagePart, data as Image);
                    }
                    row.Append(cell);
                }
                sheetData1.Append(row);
            }
        }
        // Generates content of imagePart1.
        private void GenerateImagePartContent(ImagePart imagePart, Image image)
        {
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            imagePart.FeedData(memStream);
            memStream.Close();
        }
        private Xdr.TwoCellAnchor AddTwoCellAnchor(int startRow, int startColumn, int endRow, int endColumn, string imagerId)
        {
            Xdr.TwoCellAnchor twoCellAnchor1 = new Xdr.TwoCellAnchor() { EditAs = Xdr.EditAsValues.OneCell };
            Xdr.FromMarker fromMarker1 = new Xdr.FromMarker();
            Xdr.ColumnId columnId1 = new Xdr.ColumnId();
            columnId1.Text = startColumn.ToString();
            Xdr.ColumnOffset columnOffset1 = new Xdr.ColumnOffset();
            columnOffset1.Text = "0";
            Xdr.RowId rowId1 = new Xdr.RowId();
            rowId1.Text = startRow.ToString();
            Xdr.RowOffset rowOffset1 = new Xdr.RowOffset();
            rowOffset1.Text = "0";
            fromMarker1.Append(columnId1);
            fromMarker1.Append(columnOffset1);
            fromMarker1.Append(rowId1);
            fromMarker1.Append(rowOffset1);
            Xdr.ToMarker toMarker1 = new Xdr.ToMarker();
            Xdr.ColumnId columnId2 = new Xdr.ColumnId();
            columnId2.Text = endColumn.ToString();
            Xdr.ColumnOffset columnOffset2 = new Xdr.ColumnOffset();
            columnOffset2.Text = "152381";
            Xdr.RowId rowId2 = new Xdr.RowId();
            rowId2.Text = endRow.ToString();
            Xdr.RowOffset rowOffset2 = new Xdr.RowOffset();
            rowOffset2.Text = "152381";
            toMarker1.Append(columnId2);
            toMarker1.Append(columnOffset2);
            toMarker1.Append(rowId2);
            toMarker1.Append(rowOffset2);
            Xdr.Picture picture1 = new Xdr.Picture();
            Xdr.NonVisualPictureProperties nonVisualPictureProperties1 = new Xdr.NonVisualPictureProperties();
            Xdr.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Xdr.NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Picture 1" };
            Xdr.NonVisualPictureDrawingProperties nonVisualPictureDrawingProperties1 = new Xdr.NonVisualPictureDrawingProperties();
            A.PictureLocks pictureLocks1 = new A.PictureLocks() { NoChangeAspect = true };
            nonVisualPictureDrawingProperties1.Append(pictureLocks1);
            nonVisualPictureProperties1.Append(nonVisualDrawingProperties1);
            nonVisualPictureProperties1.Append(nonVisualPictureDrawingProperties1);
            Xdr.BlipFill blipFill1 = new Xdr.BlipFill();
            A.Blip blip1 = new A.Blip() { Embed = imagerId };
            blip1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            A.BlipExtensionList blipExtensionList1 = new A.BlipExtensionList();
            A.BlipExtension blipExtension1 = new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" };
            A14.UseLocalDpi useLocalDpi1 = new A14.UseLocalDpi() { Val = false };
            useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");
            blipExtension1.Append(useLocalDpi1);
            blipExtensionList1.Append(blipExtension1);
            blip1.Append(blipExtensionList1);
            A.Stretch stretch1 = new A.Stretch();
            A.FillRectangle fillRectangle1 = new A.FillRectangle();
            stretch1.Append(fillRectangle1);
            blipFill1.Append(blip1);
            blipFill1.Append(stretch1);
            Xdr.ShapeProperties shapeProperties1 = new Xdr.ShapeProperties();
            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents() { Cx = 152381L, Cy = 152381L };
            transform2D1.Append(offset1);
            transform2D1.Append(extents1);
            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();
            presetGeometry1.Append(adjustValueList1);
            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            picture1.Append(nonVisualPictureProperties1);
            picture1.Append(blipFill1);
            picture1.Append(shapeProperties1);
            Xdr.ClientData clientData1 = new Xdr.ClientData();
            twoCellAnchor1.Append(fromMarker1);
            twoCellAnchor1.Append(toMarker1);
            twoCellAnchor1.Append(picture1);
            twoCellAnchor1.Append(clientData1);
            return twoCellAnchor1;
        }
        /// <summary>
        /// Generates the SharedString xml part using the string collection in SharedStrings (List<string>)
        /// </summary>
        /// <param name="part"></param>
        private void GenerateSharedStringTablePart1Content(SharedStringTablePart part)
        {
            SharedStringTable sharedStringTable1 = new SharedStringTable();
            sharedStringTable1.Count = new UInt32Value((uint)sharedStrings.Count);
            sharedStringTable1.UniqueCount = new UInt32Value((uint)sharedStrings.Count);
            foreach (string item in sharedStrings)
            {
                SharedStringItem sharedStringItem = new SharedStringItem();
                Text text = new Text();
                text.Text = item;
                sharedStringItem.Append(text);
                sharedStringTable1.Append(sharedStringItem);
            }
            part.SharedStringTable = sharedStringTable1;
        }
        /// <summary>
        /// Gets the next relationship id
        /// </summary>
        /// <returns></returns>
        private string GetNextRelationShipId()
        {
            s_rId++;
            return "rId" + s_rId.ToString();
        }
    }
   
