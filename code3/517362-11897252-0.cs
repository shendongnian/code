        public static void FormatAsDate(UltraGridColumn cl)
        {
            cl.CellAppearance.TextHAlign = HAlign.Left;
            cl.Header.Appearance.TextHAlign = HAlign.Left;
            cl.MaskInput = "dd/MM/yyyy hh:mm:ss";
            cl.PromptChar = ' ';
            cl.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateWithoutDropDown;
        }
