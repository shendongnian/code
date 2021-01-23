    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        public partial class frmCodeEditor : Form
        {
            char[] chrTracingKeyChars = new char[] { ';', '}', '\n' };
            char[] chrCheckingKeyChars = new char[] { '{', '(' };
            Point ptCurrentCharPosition;
            bool bolCheckCalling = false;
            int intInitialCursorPosition = 0;
            int intRemainingCharsOfInitialText = 0;
            int intNextCharIndex = 0;
            int intPrevCharIndex = 0;
            public frmCodeEditor()
            {
                InitializeComponent();
            }
            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                AutoIndention(rtbCodes);
            }
            /// <summary>
            /// Implements Auto-Indention.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            private void AutoIndention(RichTextBox rtb)
            {
                char chrLastChar = GetChar(rtb);
                if (chrLastChar == chrTracingKeyChars[0])
                {
                    intRemainingCharsOfInitialText = rtb.TextLength - rtb.SelectionStart;
                    intInitialCursorPosition = rtb.SelectionStart;
                    ImplementIndentionForSemicolon(rtb);
                }
                else if (chrLastChar == chrTracingKeyChars[1])
                {
                    ImplementIndentionForRightCurlyBracket(rtb);
                }
                else if (chrLastChar == chrTracingKeyChars[2])
                {
                    ImplementIndentionForNewLineCharacter(rtb);
                }
            }
            /// <summary>
            /// Specifies current char based on the cursor position.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns a char.</returns>
            private char GetChar(RichTextBox rtb)
            {
                return GetChar(rtb.SelectionStart, rtb);
            }
            /// <summary>
            /// Specifies a char based on the specified index.
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns a char.</returns>
            private char GetChar(int intCharIndex, RichTextBox rtb)
            {
                if (intCharIndex != rtb.TextLength)
                {
                    ptCurrentCharPosition = rtb.GetPositionFromCharIndex(intCharIndex - 1);
                }
                else
                {
                    ptCurrentCharPosition = rtb.GetPositionFromCharIndex(intCharIndex);
                }
                return rtb.GetCharFromPosition(ptCurrentCharPosition);
            }
            /// <summary>
            /// Specifies current line number based on the cursor position.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns the line number.</returns>
            private int GetLineNumber(RichTextBox rtb)
            {
                return GetLineNumber(rtb.GetFirstCharIndexOfCurrentLine(), rtb);
            }
            /// <summary>
            /// Specifies the line number based on the specified index.
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns the line number.</returns>
            private int GetLineNumber(int intCharIndex, RichTextBox rtb)
            {
                return rtb.GetLineFromCharIndex(intCharIndex);
            }
            /// <summary>
            /// Implements indention for semicolon ";" character.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            private void ImplementIndentionForSemicolon(RichTextBox rtb)
            {
                Dictionary<char, int> dicResult = IsExistCheckingKeyChars(rtb);
                if (dicResult[chrCheckingKeyChars[0]] != -1)
                {
                    int intIndentionLevel = CheckingIndentionLevel(dicResult[chrCheckingKeyChars[0]], rtb);
                    ImplementIndention(dicResult[chrCheckingKeyChars[0]], intIndentionLevel, rtb);
                }
            }
            private void ImplementIndentionForRightCurlyBracket(RichTextBox rtb)
            {
            }
            private void ImplementIndentionForNewLineCharacter(RichTextBox rtb)
            {
            }
            /// <summary>
            /// Checks current and previous lines for finding key-chars.
            /// </summary>
            /// <param name="rtb">A RichTextBox control</param>
            /// <param name="bolSearchCurrentLine">The search state</param>
            /// <returns>Returns first occurrences of key-chars before current char.</returns>
            private Dictionary<char, int> IsExistCheckingKeyChars(RichTextBox rtb, bool bolSearchCurrentLine = false)
            {
                GetChar(rtb);
                Dictionary<char, int> dicCheckingKeyCharsIndexes = new Dictionary<char, int>();
                for (int intCntr = 0; intCntr < chrCheckingKeyChars.Length; intCntr++)
                {
                    dicCheckingKeyCharsIndexes.Add(chrCheckingKeyChars[intCntr], 0);
                }
                for (int intCntr = 0; intCntr < chrCheckingKeyChars.Length; intCntr++)
                {
                    int intFirstIndexForChecking = 0;
                    int intLastIndexForChecking = 0;
                    for (int intLineCounter = GetLineNumber(rtb); intLineCounter >= 0; intLineCounter--)
                    {
                        if (intLineCounter == GetLineNumber(rtb))
                        {
                            intLastIndexForChecking = rtb.GetCharIndexFromPosition(ptCurrentCharPosition);
                        }
                        else
                        {
                            intLastIndexForChecking = intFirstIndexForChecking - 1;
                        }
                        intFirstIndexForChecking = rtb.GetFirstCharIndexFromLine(intLineCounter);
                        try
                        {
                            dicCheckingKeyCharsIndexes[chrCheckingKeyChars[intCntr]] = rtb.Find(chrCheckingKeyChars[intCntr].ToString(), intFirstIndexForChecking,
                                rtb.GetCharIndexFromPosition(ptCurrentCharPosition), RichTextBoxFinds.NoHighlight | RichTextBoxFinds.None);
                            if (dicCheckingKeyCharsIndexes[chrCheckingKeyChars[intCntr]] != -1)
                            {
                                do
                                {
                                    if (rtb.Find(chrCheckingKeyChars[intCntr].ToString(), intFirstIndexForChecking, rtb.GetCharIndexFromPosition(ptCurrentCharPosition),
                                        RichTextBoxFinds.NoHighlight | RichTextBoxFinds.None) != -1)
                                    {
                                        dicCheckingKeyCharsIndexes[chrCheckingKeyChars[intCntr]] = rtb.Find(chrCheckingKeyChars[intCntr].ToString(), intFirstIndexForChecking,
                                            rtb.GetCharIndexFromPosition(ptCurrentCharPosition), RichTextBoxFinds.NoHighlight | RichTextBoxFinds.None);
                                    }
                                    intFirstIndexForChecking++;
                                } while (intFirstIndexForChecking != rtb.GetCharIndexFromPosition(ptCurrentCharPosition));
                                break;
                            }
                        }
                        catch
                        {
                            dicCheckingKeyCharsIndexes[chrCheckingKeyChars[intCntr]] = -1;
                            break;
                        }
                        if (bolSearchCurrentLine)
                        {
                            break;
                        }
                    }
                }
                return dicCheckingKeyCharsIndexes;
            }
            /// <summary>
            /// Checks a line for calculating its indention level.
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="rtb">A RichTextBox control</param>
            /// <returns>Returns indention level of the line.</returns>
            private int CheckingIndentionLevel(int intCharIndex, RichTextBox rtb)
            {
                int intLineNumber = GetLineNumber(intCharIndex, rtb);
                int intIndentionLevelNumber = 0;
                intCharIndex = rtb.GetFirstCharIndexFromLine(intLineNumber);
                char chrChar = GetChar(intCharIndex, rtb);
                if (chrChar == '\n')
                {
                    chrChar = GetChar(++intCharIndex, rtb);
                }
                if (chrChar != ' ')
                {
                    return 0;
                }
                else
                {
                    int intSpaceCntr = 0;
                    while(chrChar == ' ')
                    {
                        chrChar = GetChar(++intCharIndex, rtb);
                        if (chrChar == ' ')
                        {
                            intSpaceCntr++;
                        }
                        if (intSpaceCntr % 4 == 0 && intSpaceCntr != 0)
                        {
                            intIndentionLevelNumber++;
                            intSpaceCntr = 0;
                        }
                    }
                    if (intSpaceCntr % 4 != 0)
                    {
                        intIndentionLevelNumber++;
                    }
                }
                return intIndentionLevelNumber;
            }
            /// <summary>
            /// Implements Indention to the codes
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="intIndentionLevel">The number of indention level</param>
            /// <param name="rtb">A RichTextBox control</param>
            private void ImplementIndention(int intCharIndex, int intIndentionLevel, RichTextBox rtb)
            {
                intNextCharIndex = intCharIndex;
                intPrevCharIndex = intCharIndex;
                int intKeyCharsNumberInLine = 1;
                int intCurrentLineNumber = GetLineNumber(rtb);
                int intKeyCharLineNumber = GetLineNumber(intNextCharIndex, rtb);
                string[] strLinesTexts;
                Dictionary<char, int> dicResult;
                do
                {
                    rtb.SelectionStart = intPrevCharIndex;
                    dicResult = IsExistCheckingKeyChars(rtb);
                    if (dicResult[chrCheckingKeyChars[0]] != -1)
                    {
                        intKeyCharsNumberInLine++;
                        intPrevCharIndex = dicResult[chrCheckingKeyChars[0]];
                    }
                } while (dicResult[chrCheckingKeyChars[0]] != -1);
                if (!bolCheckCalling)
                {
                    if (intCurrentLineNumber == intKeyCharLineNumber)
                    {
                        for (int intCntr = 1; intCntr <= intKeyCharsNumberInLine; intCntr++)
                        {
                            do
                            {
                                rtb.SelectionStart = intPrevCharIndex;
                                dicResult = IsExistCheckingKeyChars(rtb, true);
                                if (dicResult[chrCheckingKeyChars[0]] != -1)
                                {
                                    intPrevCharIndex = dicResult[chrCheckingKeyChars[0]];
                                }
                            } while (dicResult[chrCheckingKeyChars[0]] != -1);
                            bolCheckCalling = true;
                            ImplementIndention(intPrevCharIndex, rtb);
                        }
                        return;
                    }
                }
                bolCheckCalling = false;
                rtb.SelectionStart = intNextCharIndex;
                rtb.SelectionLength = 1;
                rtb.SelectedText = "\n" + rtb.SelectedText;
                intCurrentLineNumber = GetLineNumber(rtb);
                strLinesTexts = rtb.Lines;
                strLinesTexts[intCurrentLineNumber] = strLinesTexts[intCurrentLineNumber].Trim();
                for (int intIndentionCntr = 1; intIndentionCntr <= intIndentionLevel; intIndentionCntr++)
                {
                    for (int intSpaceCntr = 1; intSpaceCntr <= 4; intSpaceCntr++)
                    {
                        strLinesTexts[intCurrentLineNumber] = ' ' + strLinesTexts[intCurrentLineNumber];
                    }
                }
                rtb.Lines = strLinesTexts;
                rtb.SelectionStart = intNextCharIndex + ((intIndentionLevel * 4) + 1);
                intNextCharIndex = rtb.SelectionStart;
                rtb.SelectionLength = 1;
                rtb.SelectedText = rtb.SelectedText + "\n";
                intCurrentLineNumber = GetLineNumber(rtb);
                strLinesTexts = rtb.Lines;
                strLinesTexts[intCurrentLineNumber] = strLinesTexts[intCurrentLineNumber].Trim();
                for (int intIndentionCntr = 1; intIndentionCntr <= intIndentionLevel + 1; intIndentionCntr++)
                {
                    for (int intSpaceCntr = 1; intSpaceCntr <= 4; intSpaceCntr++)
                    {
                        strLinesTexts[intCurrentLineNumber] = ' ' + strLinesTexts[intCurrentLineNumber];
                    }
                }
                rtb.Lines = strLinesTexts;
                rtb.SelectionStart = intInitialCursorPosition + ((rtb.TextLength - intInitialCursorPosition) - intRemainingCharsOfInitialText);
                intNextCharIndex = rtb.SelectionStart;
                intPrevCharIndex = intNextCharIndex;
            }
            /// <summary>
            /// Implements Indention to the codes
            /// </summary>
            /// <param name="intCharIndex">A char index</param>
            /// <param name="rtb">A RichTextBox control</param>
            private void ImplementIndention(int intCharIndex, RichTextBox rtb)
            {
                int intIndentionLevel = CheckingIndentionLevel(intCharIndex, rtb);
                ImplementIndention(intCharIndex, intIndentionLevel, rtb);
            }
        }
    }
