    class Utils
    {
        [DllImport("user32.dll")]
        static extern bool GetCaretPos(out System.Drawing.Point lpPoint);
        public static void LineUp(TextBox tb)
        {
            int oldCharIndex = tb.SelectionStart;
            int oldLineNo = tb.GetLineFromCharIndex(oldCharIndex);
            System.Drawing.Point oldCharPos = tb.GetPositionFromCharIndex(oldCharIndex);
            System.Drawing.Point oldCaretPos;
            if (GetCaretPos(out oldCaretPos))
            {
                if (oldCharPos == oldCaretPos)
                {
                    if (oldLineNo > 0)
                    {
                        tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo - 1);
                        tb.ScrollToCaret();
                        System.Drawing.Point newPos = new System.Drawing.Point(oldCaretPos.X, oldCaretPos.Y - tb.Font.Height);
                        int newCharIndex = tb.GetCharIndexFromPosition(newPos);
                        if (tb.GetPositionFromCharIndex(newCharIndex).Y == newPos.Y)
                        {
                            tb.SelectionStart = newCharIndex;
                        }
                        else
                        {
                            tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo - 1);
                            System.Windows.Forms.SendKeys.Send("{END}");
                        }
                    }
                }
                else
                {
                    if (oldLineNo > 1)
                    {
                        tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo - 2);
                        tb.ScrollToCaret();
                        System.Drawing.Point newPos = new System.Drawing.Point(oldCaretPos.X, oldCaretPos.Y - tb.Font.Height);
                        int newCharIndex = tb.GetCharIndexFromPosition(newPos);
                        if (tb.GetPositionFromCharIndex(newCharIndex).Y == newPos.Y)
                        {
                            tb.SelectionStart = newCharIndex;
                        }
                        else
                        {
                            tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo - 2);
                            System.Windows.Forms.SendKeys.Send("{END}");
                        }
                    }
                }
            }
        }
        public static void LineDown(TextBox tb)
        {
            int oldCharIndex = tb.SelectionStart;
            int oldLineNo = tb.GetLineFromCharIndex(oldCharIndex);
            System.Drawing.Point oldCharPos = tb.GetPositionFromCharIndex(oldCharIndex);
            System.Drawing.Point oldCaretPos;
            if (GetCaretPos(out oldCaretPos))
            {
                if (oldCharPos == oldCaretPos)
                {
                    if (oldLineNo < tb.GetLineFromCharIndex(tb.Text.Length - 1))
                    {
                        tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo + 1);
                        tb.ScrollToCaret();
                        System.Drawing.Point newPos = new System.Drawing.Point(oldCaretPos.X, oldCaretPos.Y + tb.Font.Height);
                        int newCharIndex = tb.GetCharIndexFromPosition(newPos);
                        if (tb.GetPositionFromCharIndex(newCharIndex).Y == newPos.Y)
                        {
                            tb.SelectionStart = newCharIndex;
                        }
                        else
                        {
                            tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo + 1);
                            System.Windows.Forms.SendKeys.Send("{END}");
                        }
                    }
                }
                else
                {
                    System.Drawing.Point newPos = new System.Drawing.Point(oldCaretPos.X, oldCaretPos.Y + tb.Font.Height);
                    int newCharIndex = tb.GetCharIndexFromPosition(newPos);
                    if (tb.GetPositionFromCharIndex(newCharIndex).Y == newPos.Y)
                    {
                        tb.SelectionStart = newCharIndex;
                    }
                    else
                    {
                        tb.SelectionStart = tb.GetFirstCharIndexFromLine(oldLineNo);
                        System.Windows.Forms.SendKeys.Send("{END}");
                    }
                }
            }
        }
    }
