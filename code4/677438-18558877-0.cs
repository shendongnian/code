    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    namespace CodeEditor
    {
        public partial class Form1 : Form
        {
            #region Variables
            private Dictionary<string, string> hintTexts = new Dictionary<string, string>();
            private string strCurrentHintText = null;
            private Font hintFont = new Font("Microsoft Sans Serif", 8.25f);
            private Brush hintTextColor = Brushes.Black;
            private Point hintTextLocation = new Point(2, 2);
            public Point ptCurrentCharPosition;
            Point ptHintLocation;
            int intCurrentCursorPosition = 0;
            int intCurrentSelectionLength = 0;
            List<int> lstIntLeftParenthesisCharIndexes = new List<int>();
            #endregion
            #region Properties
            #region Hint
            /// <summary>
            /// Sets the font of the hint texts.
            /// </summary>
            public Font HintFont
            {
                protected get
                {
                    return hintFont;
                }
                set
                {
                    hintFont = value;
                }
            }
            /// <summary>
            /// Sets the color of the hint texts.
            /// </summary>
            public Brush HintTextColor
            {
                protected get
                {
                    return hintTextColor;
                }
                set
                {
                    hintTextColor = value;
                }
            }
            /// <summary>
            /// Sets the location of the hint texts.
            /// </summary>
            public Point HintTextLocation
            {
                protected get
                {
                    return hintTextLocation;
                }
                set
                {
                    hintTextLocation = value;
                }
            }
            /// <summary>
            /// Gets and Sets the texts of the hints.
            /// </summary>
            public Dictionary<string, string> HintTexts
            {
                get
                {
                    return hintTexts;
                }
                set
                {
                    hintTexts = value;
                }
            }
            #endregion
            #endregion
            public Form1()
            {
                InitializeComponent();
            }
            #region Methods
            #region GetChar
            /// <summary>
            /// Specifies current char based on the cursor position.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns a char.</returns>
            public char GetChar(System.Windows.Forms.RichTextBox rtb)
            {
                return GetChar(rtb.SelectionStart, rtb);
            }
            /// <summary>
            /// Specifies a char based on the specified position.
            /// </summary>
            /// <param name="intCharIndex">A position coordinates</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns a char.</returns>
            public char GetChar(Point ptCurrentPosition, System.Windows.Forms.RichTextBox rtb)
            {
                return rtb.GetCharFromPosition(ptCurrentPosition);
            }
            /// <summary>
            /// Specifies a char based on the specified index.
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns a char.</returns>
            public char GetChar(int intCharIndex, System.Windows.Forms.RichTextBox rtb)
            {
                if (intCharIndex > 0 && rtb.GetPositionFromCharIndex(intCharIndex).X == 0 && rtb.GetPositionFromCharIndex(intCharIndex).Y == 0)
                {
                    return '▓'; // Invalid char
                }
                if (intCharIndex != rtb.TextLength)
                {
                    ptCurrentCharPosition = rtb.GetPositionFromCharIndex(intCharIndex - 1);
                }
                else
                {
                    ptCurrentCharPosition = rtb.GetPositionFromCharIndex(intCharIndex);
                }
                return GetChar(ptCurrentCharPosition, rtb);
            }
            #endregion
            /// <summary>
            /// Find the text (keyword) before the specific character.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            /// <param name="intKeyValue">The value of the pressed key</param>
            /// <param name="strText">The text (keyword) before last typed character for checking it</param>
            /// <returns>Returns found text (keyword).</returns>
            private string FindKeyword(System.Windows.Forms.RichTextBox rtb, int intKeyValue, string strText)
            {
                string strSelectedText = null;
                try
                {
                    if (intKeyValue == 57) // ( char
                    {
                        if (rtb.SelectionStart - 1 >= 0)
                        {
                            rtb.SelectionStart--;
                            rtb.SelectionLength = 1;
                        }
                        if (rtb.SelectionStart - strText.Length >= 0)
                        {
                            rtb.SelectionStart -= strText.Length;
                            rtb.SelectionLength = strText.Length;
                        }
                        strSelectedText = rtb.SelectedText;
                        if (rtb.SelectionStart - strText.Length >= 0)
                        {
                            rtb.SelectionStart += strText.Length;
                            rtb.SelectionLength = 1;
                        }
                        if (rtb.SelectionStart - 1 >= 0)
                        {
                            rtb.SelectionStart++;
                            rtb.SelectionLength = 0;
                        }
                    }
                }
                catch
                {
                }
                return strSelectedText;
            }
            /// <summary>
            /// Displays a hint in the current cursor position.
            /// </summary>
            /// <param name="ttip">A ToolTip control</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <param name="intKeyValue">The value of the pressed key</param>
            /// <param name="strCheckingText">The text (keyword) before last typed character for checking it and diplaying its related hint</param>
            /// <param name="strHintText">The text of the hint for current keyword</param>
            private void ShowHint(ToolTip ttip, System.Windows.Forms.RichTextBox rtb, int intKeyValue, string strCheckingText, string strHintText)
            {
                try
                {
                    if (rtb.SelectionStart - 1 >= 0)
                    {
                        rtb.SelectionStart--;
                        rtb.SelectionLength = 1;
                    }
                    if (intKeyValue == 57) // ( char
                    {
                        if (rtb.SelectionStart - strCheckingText.Length >= 0)
                        {
                            rtb.SelectionStart -= strCheckingText.Length;
                            rtb.SelectionLength = strCheckingText.Length;
                        }
                        if (rtb.SelectedText == strCheckingText)
                        {
                            rtb.SelectionStart += strCheckingText.Length;
                            rtb.SelectionLength = 1;
                            lstIntLeftParenthesisCharIndexes.Add(rtb.SelectionStart);
                        }
                        if (GetChar(lstIntLeftParenthesisCharIndexes.Last() + 1, rtb) != '(')
                        {
                            lstIntLeftParenthesisCharIndexes.Remove(lstIntLeftParenthesisCharIndexes.Count - 1);
                        }
                        ttip.ShowAlways = true;
                        ttip.OwnerDraw = true;
                        intCurrentCursorPosition = rtb.SelectionStart;
                        intCurrentSelectionLength = rtb.SelectionLength;
                        rtb.SelectionStart += rtb.SelectionLength - 1;
                        rtb.SelectionLength = 0;
                        GetChar(rtb);
                        ptHintLocation = ptCurrentCharPosition;
                        ptHintLocation.X += 2;
                        ptHintLocation.X += TextRenderer.MeasureText(rtb.Lines[0], rtb.Font).Height;
                        ptHintLocation.Y += 1;
                        ptHintLocation.Y += 2;
                        ptHintLocation.Y += TextRenderer.MeasureText(rtb.Lines[0], rtb.Font).Height;
                        rtb.SelectionStart = intCurrentCursorPosition;
                        rtb.SelectionLength = intCurrentSelectionLength;
                        strCurrentHintText = strHintText;
                        ttip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(ttipHint_Draw);
                        ttip.Popup += new System.Windows.Forms.PopupEventHandler(ttipHint_Popup);
                        if (rtb.SelectionStart - strCheckingText.Length >= 0)
                        {
                            rtb.SelectionStart -= strCheckingText.Length;
                            rtb.SelectionLength = strCheckingText.Length;
                        }
                        if (rtb.SelectedText == strCheckingText)
                        {
                            rtb.SelectionStart += strCheckingText.Length;
                            rtb.SelectionStart++;
                            rtb.SelectionLength = 0;
                            try
                            {
                                HintTexts.Add(strCheckingText, strHintText);
                            }
                            catch
                            {
                                for (int intCntr = 0; intCntr < HintTexts.Count; intCntr++)
                                {
                                    if (HintTexts.ElementAt(intCntr).Key == strCheckingText)
                                    {
                                        strCheckingText += intCntr + 1;
                                    }
                                }
                                HintTexts.Add(strCheckingText, strHintText);
                            }
                            ttip.Show(strHintText, rtb, ptHintLocation);
                            rtb.SelectionStart--;
                            rtb.SelectionLength = 1;
                        }
                    }
                    else if (intKeyValue == 48) // ) char
                    {
                        lstIntLeftParenthesisCharIndexes.Remove(lstIntLeftParenthesisCharIndexes.Count - 1);
                        HintTexts.Remove(HintTexts.Last().Key);
                        if (lstIntLeftParenthesisCharIndexes.Count == 0)
                        {
                            ttip.ShowAlways = false;
                            ttip.RemoveAll();
                            ttip.Draw -= ttipHint_Draw;
                            ttip.Popup -= ttipHint_Popup;
                        }
                        else
                        {
                            try
                            {
                                strCurrentHintText = HintTexts.Last().Value;
                                ttip.Show(HintTexts.Last().Value, rtb, ptHintLocation);
                            }
                            catch
                            {
                                ttip.ShowAlways = false;
                                ttip.RemoveAll();
                                ttip.Draw -= ttipHint_Draw;
                                ttip.Popup -= ttipHint_Popup;
                            }
                        }
                    }
                    else if (intKeyValue == 13) // New Line char (Enter/Return key)
                    {
                        if (ttip.ShowAlways)
                        {
                            GetChar(rtb);
                            ptHintLocation = ptCurrentCharPosition;
                            ptHintLocation.Y -= TextRenderer.MeasureText(strHintText, HintFont).Height + HintTextLocation.Y;
                            ttip.Show(strHintText, rtb, ptHintLocation);
                        }
                    }
                    else if (intKeyValue == 8) // Backspace key
                    {
                        for (int intCntr = 0; intCntr < lstIntLeftParenthesisCharIndexes.Count; intCntr++)
                        {
                            char chr = GetChar(lstIntLeftParenthesisCharIndexes[intCntr] + 1, rtb);
                            if (GetChar(lstIntLeftParenthesisCharIndexes[intCntr] + 1, rtb) != '(')
                            {
                                lstIntLeftParenthesisCharIndexes.Remove(lstIntLeftParenthesisCharIndexes[intCntr]);
                            }
                        }
                        ttip.ShowAlways = false;
                        ttip.RemoveAll();
                        ttip.Draw -= ttipHint_Draw;
                        ttip.Popup -= ttipHint_Popup;
                    }
                    if (rtb.SelectionStart - 1 >= 0)
                    {
                        rtb.SelectionStart++;
                        rtb.SelectionLength = 0;
                    }
                }
                catch
                {
                    if (intKeyValue == 8) // Backspace
                    {
                        for (int intCntr = 0; intCntr < lstIntLeftParenthesisCharIndexes.Count; intCntr++)
                        {
                            char chr = GetChar(lstIntLeftParenthesisCharIndexes[intCntr] + 1, rtb);
                            if (GetChar(lstIntLeftParenthesisCharIndexes[intCntr] + 1, rtb) != '(')
                            {
                                lstIntLeftParenthesisCharIndexes.Remove(lstIntLeftParenthesisCharIndexes[intCntr]);
                            }
                        }
                        ttip.ShowAlways = false;
                        ttip.RemoveAll();
                        ttip.Draw -= ttipHint_Draw;
                        ttip.Popup -= ttipHint_Popup;
                    }
                }
            }
            #endregion
            #region Events
            private void ttipHint_Popup(object sender, PopupEventArgs e)
            {
                e.ToolTipSize = new Size(TextRenderer.MeasureText(strCurrentHintText, HintFont).Width + (HintTextLocation.X * 2),
                    TextRenderer.MeasureText(strCurrentHintText, HintFont).Height + (HintTextLocation.Y * 2));
            }
            private void ttipHint_Draw(object sender, DrawToolTipEventArgs e)
            {
                try
                {
                    using (e.Graphics)
                    {
                        e.DrawBackground();
                        e.DrawBorder();
                        e.Graphics.DrawString(strCurrentHintText, HintFont, HintTextColor, HintTextLocation);
                    }
                }
                catch
                {
                }
            }
            private void rtb1_KeyUp(object sender, KeyEventArgs e)
            {
                HintFont = new Font("Arial", 9f);
                HintTextColor = Brushes.Blue;
                HintTextLocation = new Point(10, 10);
                if (FindKeyword(rtb1, e.KeyValue, "Sample1") == "Sample1")
                {
                    ShowHint(ttipHint, rtb1, e.KeyValue, "Sample1", "This is an example 1.");
                }
                else if (FindKeyword(rtb1, e.KeyValue, "Sample2") == "Sample2")
                {
                    ShowHint(ttipHint, rtb1, e.KeyValue, "Sample2", "This is an example 2.\nThis is an example 2. This is an example 2.");
                }
                else if (FindKeyword(rtb1, e.KeyValue, "Sample3") == "Sample3")
                {
                    ShowHint(ttipHint, rtb1, e.KeyValue, "Sample3", "This is an example 3.\nThis is an example 3. This is an example 3.\nThis is an example 3. This is an example 3. This is an example 3.");
                }
                else
                {
                    try
                    {
                        if (e.KeyValue == 48 || e.KeyValue == 13 || e.KeyValue == 8)
                        {
                            ShowHint(ttipHint, rtb1, e.KeyValue, HintTexts.Last().Key, HintTexts.Last().Value);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            #endregion
        }
    }
