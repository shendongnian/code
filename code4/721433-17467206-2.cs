        public enum NumericTextBoxType { TDecimal = 1, TByte, TShort, TInt, TLong }
    
        public class NumericTextBox : TextBox
        {
    
            #region ARRAYS
    
            private Keys[] separators = 
    {
    Keys.Decimal,
    Keys.Oemcomma,
    Keys.OemPeriod
    };
    
            private Keys[] allowed =
    {
    Keys.D1,
    Keys.D2,
    Keys.D3,
    Keys.D4,
    Keys.D5,
    Keys.D6,
    Keys.D7,
    Keys.D8,
    Keys.D9,
    Keys.D0,
    Keys.NumPad0,
    Keys.NumPad1,
    Keys.NumPad2,
    Keys.NumPad3,
    Keys.NumPad4,
    Keys.NumPad5,
    Keys.NumPad6,
    Keys.NumPad7,
    Keys.NumPad8,
    Keys.NumPad9,
    Keys.Decimal,
    Keys.Oemcomma,
    Keys.OemPeriod,
    Keys.OemMinus,
    Keys.Subtract,
    Keys.Back,
    Keys.Delete,
    Keys.Tab,
    Keys.Enter,
    Keys.Up,
    Keys.Down,
    Keys.Left,
    Keys.Right
    };
    
            private Keys[] intallowed =
    {
    Keys.D1,
    Keys.D2,
    Keys.D3,
    Keys.D4,
    Keys.D5,
    Keys.D6,
    Keys.D7,
    Keys.D8,
    Keys.D9,
    Keys.D0,
    Keys.NumPad0,
    Keys.NumPad1,
    Keys.NumPad2,
    Keys.NumPad3,
    Keys.NumPad4,
    Keys.NumPad5,
    Keys.NumPad6,
    Keys.NumPad7,
    Keys.NumPad8,
    Keys.NumPad9,
    Keys.OemMinus,
    Keys.Subtract,
    Keys.Back,
    Keys.Delete,
    Keys.Tab,
    Keys.Enter,
    Keys.Up,
    Keys.Down,
    Keys.Left,
    Keys.Right
    };
    
            #endregion ARRAYS
    
            #region PROPERTY NumericTextBoxType
    
            private NumericTextBoxType _NumericTextBoxType = NumericTextBoxType.TDecimal;
    
            public NumericTextBoxType NumericTextBoxType
            {
                get
                {
                    return
                    _NumericTextBoxType;
                }
                set
                {
                    _NumericTextBoxType = value;
                }
            }
    
            #endregion PROPERTY NumericTextBoxType
    
            #region PROPERTY AllowMinus
    
            public bool AllowMinus { get; set; }
    
            #endregion
    
            public NumericTextBox()
                : base()
            {
                this.NumericTextBoxType = NumericTextBoxType.TDecimal;
                this.AllowMinus = true;
            }
    
            #region EVENT METHOD OnKeyDown
    
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (e.Modifiers == Keys.Control) return;
    
                // ignore not allowed
                if (NumericTextBoxType != NumericTextBoxType.TDecimal)
                {
                    if (!intallowed.Contains(e.KeyCode)) e.SuppressKeyPress = true;
                }
                else
                {
                    if (!allowed.Contains(e.KeyCode)) e.SuppressKeyPress = true;
                    else if (separators.Contains(e.KeyCode))
                    {
                        NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                        string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
    
                        int selLength = this.SelectionLength;
                        int selStart = this.SelectionStart;
    
                        if (!this.Text.Remove(selStart, selLength).Contains(decimalSeparator))
                        {
                            this.Text = this.Text
                            .Remove(selStart, selLength)
                            .Insert(this.SelectionStart, decimalSeparator);
                            this.SelectionStart = selStart + decimalSeparator.Length;
                        }
                        e.SuppressKeyPress = true;
                    }
                }
    
                // ignore minus if not first or not allowed
                if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                {
                    if (!this.AllowMinus) e.SuppressKeyPress = true;
                    else if (NumericTextBoxType == NumericTextBoxType.TByte) e.SuppressKeyPress = true;
                    else if (this.SelectionStart > 0) e.SuppressKeyPress = true;
                }
            }
    
            #endregion EVENT METHOD OnKeyDown
   
        }
