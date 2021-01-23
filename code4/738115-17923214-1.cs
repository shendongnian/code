        static bool IsOpen(string book)
        {
            foreach (_Workbook wb in xlApp.Workbooks)
            {
                if (wb.Name.Contains(book))
                {
                    return true;
                }
            }
            return false;
        }
