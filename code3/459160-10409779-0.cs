    private void ChangeCase()
        {
            try
            {
                TextPointer start;
                TextPointer end;
                FindSelectedRange(out start, out end);
                List<TextRange> textToChange = SplitToTextRanges(start, end);
                ChangeCaseToAllRanges(textToChange);
            }
            catch (Exception ex)
            {
                mLog.Error("Change case error", ex);
            }
            
            
        }
        private void FindSelectedRange(out TextPointer start, out TextPointer end)
        {
            if (!this.Selection.IsEmpty)
            {
                start = this.Selection.Start;
                end = this.Selection.End;
            }
            else
            {
                end = this.CaretPosition;
                EditingCommands.MoveLeftByWord.Execute(null, this);
                start = this.CaretPosition;
                this.CaretPosition = end;
            }
        }
        private static List<TextRange> SplitToTextRanges(TextPointer start, TextPointer end)
        {
            List<TextRange> textToChange = new List<TextRange>();
            var previousPointer = start;
            for (var pointer = start; pointer.CompareTo(end) <= 0; pointer = pointer.GetPositionAtOffset(1, LogicalDirection.Forward))
            {
                var contextAfter = pointer.GetPointerContext(LogicalDirection.Forward);
                var contextBefore = pointer.GetPointerContext(LogicalDirection.Backward);
                if (contextBefore != TextPointerContext.Text && contextAfter == TextPointerContext.Text)
                {
                    previousPointer = pointer;
                }
                if (contextBefore == TextPointerContext.Text &&  contextAfter != TextPointerContext.Text && previousPointer != pointer)
                {
                    textToChange.Add(new TextRange(previousPointer, pointer));
                    previousPointer = null;
                }
            }
            textToChange.Add(new TextRange(previousPointer ?? end, end));
            return textToChange;
        }
        private void ChangeCaseToAllRanges(List<TextRange> textToChange)
        {
            var textInfo = (mCasingCulture ?? CultureInfo.CurrentUICulture).TextInfo;
            var allText = String.Join(" ", textToChange.Select(x => x.Text).Where(x => !string.IsNullOrWhiteSpace(x)));
            Func<string, string> caseChanger = GetConvertorToNextState(textInfo, allText);
            foreach (var range in textToChange)
            {
                if (!range.IsEmpty && !string.IsNullOrWhiteSpace(range.Text))
                {
                    range.Text = caseChanger(range.Text);
                }
            }
        }
        private static Func<string, string> GetConvertorToNextState(TextInfo textInfo, string allText)
        {
            Func<string, string> caseChanger;
            if (textInfo.ToLower(allText) == allText)
            {
                caseChanger = (text) => textInfo.ToTitleCase(text);
            }
            else if (textInfo.ToTitleCase(textInfo.ToLower(allText)) == allText)
            {
                caseChanger = (text) => textInfo.ToUpper(text);
            }
            else
            {
                caseChanger = (text) => textInfo.ToLower(text);
            }
            return caseChanger;
        }
