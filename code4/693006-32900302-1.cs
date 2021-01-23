    public static class ExportHelper
    {
        internal static void GetWinnersAsExcelMemoryStream(MemoryStream stream, List<DrawingWinner> winnerList, int drawingId)
        {
            
            ExcelFile ef = new ExcelFile();
            // lots of excel worksheet building/formatting code here ...
            ef.SaveXlsx(stream);
            stream.Position = 0; // reset for future read
         }
    }
