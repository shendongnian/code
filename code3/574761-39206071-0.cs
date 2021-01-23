            for (int i = 1; i < countToCopy; i++)
            {
                var range = worksheet.get_Range(string.Format("{0}:{0}", startRowIndex, Type.Missing));
                range.Select();
                range.Copy();
                range = worksheet.get_Range(string.Format("{0}:{1}", startRowIndex + i, startRowIndex + i, Type.Missing));
                range.Select();
                range.Insert(-4121);
            }
        }
