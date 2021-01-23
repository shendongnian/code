    using System; 
    using System.ComponentModel; 
    using System.Text; 
    using System.Windows.Forms; 
    using System.Drawing; 
     
    namespace CustomControls 
    { 
        public enum PasteRejectReasons 
        { 
            Unknown = 0, 
            NoData, 
            InvalidCharacter, 
            Accepted 
        } 
     
        public class DecimalTextBox : TextBox 
        { 
            public const int WM_PASTE = 0x0302; 
            public event EventHandler<KeyRejectedEventArgs> KeyRejected; 
            public event EventHandler<PasteEventArgs> PasteRejected; 
            private bool _DecimalSeparator = false; 
            private int _Precision; 
            public new HorizontalAlignment TextAlign 
            { 
                get { return base.TextAlign; } 
                set { base.TextAlign = value; } 
            } 
            public int Precision 
            { 
                get { return _Precision; } 
                set { _Precision = value; } 
            } 
     
            public DecimalTextBox() 
            { 
                TextAlign = HorizontalAlignment.Right; 
                Precision = 3; 
            } 
            protected override void OnGotFocus(EventArgs e) 
            { 
                SelectAll(); 
                base.OnGotFocus(e); 
            } 
            protected override void OnKeyDown(KeyEventArgs e) 
            { 
                bool validate = true; 
     
                if (Text.Contains(".") || Text.Contains(",")) 
                { 
                    int indexSep; 
                    string[] split; 
                    string partiDecimal = ""; 
     
                    if (Text.Contains(".")) 
                        indexSep = Text.IndexOf('.'); 
                    else 
                        indexSep = Text.IndexOf(','); 
     
                    split = Text.Split(new char[] { ',', '.' }); 
                    partiDecimal += split[1]; 
     
                    if (partiDecimal.Length >= Precision) 
                        if (SelectionStart > Text.Length - (partiDecimal.Length + 1)) 
                            validate = false; 
                } 
     
                bool result = true; 
     
                bool validateKeys = (e.KeyCode == Keys.Enter); 
     
                bool numericKeys = ( 
                    ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || 
                    (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) 
                    && e.Modifiers != Keys.Shift 
                    && validate); 
     
                bool ctrlA = e.KeyCode == Keys.A && e.Modifiers == Keys.Control; 
     
                bool editKeys = ( 
                    (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control) || 
                    (e.KeyCode == Keys.X && e.Modifiers == Keys.Control) || 
                    (e.KeyCode == Keys.C && e.Modifiers == Keys.Control) || 
                    (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) || 
                    e.KeyCode == Keys.Delete || 
                    e.KeyCode == Keys.Back); 
     
                bool navigationKeys = ( 
                    e.KeyCode == Keys.Up || 
                    e.KeyCode == Keys.Right || 
                    e.KeyCode == Keys.Down || 
                    e.KeyCode == Keys.Left || 
                    e.KeyCode == Keys.Home || 
                    e.KeyCode == Keys.End); 
     
                bool decimalSeparator = (( 
                    e.KeyCode == Keys.Decimal || 
                    e.KeyValue == 190 || 
                    e.KeyValue == 188)&& 
                    TextLength != 0 && 
                    SelectionLength == 0); 
     
                if (decimalSeparator)  
                { 
                    if (!_DecimalSeparator) 
                        _DecimalSeparator = true; 
                    else 
                        decimalSeparator = false; 
                } 
     
                if (!(numericKeys || editKeys || navigationKeys || decimalSeparator || validateKeys)) 
                { 
                    if (ctrlA)
                        SelectAll();
                    result = false; 
                } 
     
                if (!result)
                { 
                    e.SuppressKeyPress = true; 
                    e.Handled = true; 
                    if (!ctrlA)
                        OnKeyRejected(new KeyRejectedEventArgs(e.KeyCode)); 
                } 
                else 
                    base.OnKeyDown(e); 
            } 
            protected override void OnKeyPress(KeyPressEventArgs e) 
            { 
                if (e.KeyChar == ';' || e.KeyChar == '?') 
                { 
                    if (!(Text.Contains(",") || Text.Contains("."))) 
                        _DecimalSeparator = false; 
                    e.Handled = true; 
                } 
            } 
            protected override void OnTextChanged(EventArgs e) 
            { 
                bool invalid = false; 
                int i = 0; 
                foreach (char c in Text) // Check for any non digit characters. 
                { 
                    if (!(char.IsDigit(c) || c == ',' || c == '.')) 
                    { 
                        invalid = true; 
                        break; 
                    } 
     
                    if (c == ',' || c == '.') 
                        i++; 
                } 
     
                if (i == 0) 
                    _DecimalSeparator = false; 
                else if (i > 1) 
                    invalid = true; 
     
                if (invalid) 
                { 
                    Text = ""; 
                    return; 
                } 
     
                if (Text.Contains(".") || Text.Contains(",")) 
                { 
                    string charSep = ""; 
                    string[] split; 
                    string partiEntier = ""; 
     
                    if (Text.Contains(".")) 
                        charSep = "."; 
                    else 
                        charSep = ","; 
     
                    split = Text.Split(new char[] { ',', '.' }); 
                    partiEntier += split[0]; 
                    if (partiEntier == "") 
                        Text = "0" + charSep + split[1]; 
                } 
                base.OnTextChanged(e); 
            } 
            protected override void WndProc(ref Message m) 
            { 
                if (m.Msg == WM_PASTE) 
                { 
                    PasteEventArgs e = CheckPasteValid(); 
                    if (e.RejectReason != PasteRejectReasons.Accepted) 
                    { 
                        m.Result = IntPtr.Zero; 
                        OnPasteRejected(e); 
                        return; 
                    } 
                } 
                base.WndProc(ref m); 
            } 
 
            private PasteEventArgs CheckPasteValid() 
            { 
                PasteRejectReasons rejectReason = PasteRejectReasons.Accepted; 
                string originalText = Text; 
                string clipboardText = string.Empty; 
                string textResult = string.Empty; 
     
                try 
                { 
                    clipboardText = Clipboard.GetText(TextDataFormat.Text); 
                    if (clipboardText.Length > 0)
                    { 
                        textResult = ( 
                            Text.Remove(SelectionStart, SelectionLength).Insert(SelectionStart, clipboardText)); 
                        foreach (char c in clipboardText)
                        { 
                            if (!char.IsDigit(c)) 
                            { 
                                rejectReason = PasteRejectReasons.InvalidCharacter; 
                                break; 
                            } 
                        } 
                    } 
                    else 
                        rejectReason = PasteRejectReasons.NoData; 
                } 
                catch 
                { 
                    rejectReason = PasteRejectReasons.Unknown; 
                } 
                return new PasteEventArgs(originalText, clipboardText, textResult, rejectReason); 
            } 
            protected virtual void OnKeyRejected(KeyRejectedEventArgs e) 
            { 
                EventHandler<KeyRejectedEventArgs> handler = KeyRejected; 
                if (handler != null) 
                    handler(this, e); 
            } 
            protected virtual void OnPasteRejected(PasteEventArgs e) 
            { 
                EventHandler<PasteEventArgs> handler = PasteRejected; 
                if (handler != null) 
                    handler(this, e); 
            } 
        } 
    }
