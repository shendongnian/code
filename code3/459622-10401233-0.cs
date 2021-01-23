        public void FindTextAndSetToBold(string text)
        {
            Excel.Range currentFind = null;
            Excel.Range firstFind = null;
            // Find the first occurrence of the passed-in text
            currentFind = oSheet.Cells.Find(text, Missing.Value, Excel.XlFindLookIn.xlValues,
                Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext,
                false, Missing.Value, Missing.Value);
            while (currentFind != null)
            {
                // Keep track of the first range we find
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }
                else if (currentFind.get_Address(Missing.Value, Missing.Value, Excel.XlReferenceStyle.xlA1,
                    Missing.Value, Missing.Value) ==
                    firstFind.get_Address(Missing.Value, Missing.Value, Excel.XlReferenceStyle.xlA1,
                    Missing.Value, Missing.Value))
                {
                    // We didn't move to a new range so we're done
                    break;
                }
                // We know our text is in first cell of this range, so we need to narrow down its position
                string searchResult = currentFind.get_Range("A1").Value2.ToString();
                int startPos = searchResult.IndexOf(text);
                // Set the text in the cell to bold
                currentFind.get_Range("A1").Characters[startPos + 1, text.Length].Font.Bold = true;
                // Move to the next find
                currentFind = oSheet.Cells.FindNext(currentFind);
            }
        }
