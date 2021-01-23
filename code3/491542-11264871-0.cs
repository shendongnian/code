        public static IEnumerable<Field> GetAllFieldsInSelection(this Selection selection)
        {
            foreach (Field f in selection.Document.Fields)
            {
                int fieldStart = f.Code.FormattedText.Start;
                int fieldEnd = f.Code.FormattedText.End + f.Result.Text.Count();//field code + displayed text lenght
                if (!((fieldStart < selection.Start) & (fieldEnd < selection.Start) |
                      (fieldStart > selection.End) & (fieldEnd > selection.End)))
                {
                    yield return f;
                }
            }
        }
