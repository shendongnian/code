    using System.Drawing;
    using System.Windows.Forms;
    namespace Controles.Buttons
    {
        public class BaseControl 
        {
            private static readonly ContentAlignment anyRight = ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight;
            private static readonly ContentAlignment anyBottom = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
            private static readonly ContentAlignment anyCenter = ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter;
            private static readonly ContentAlignment anyMiddle = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;
            static StringAlignment TranslateAlignment(ContentAlignment align)
            {
                StringAlignment result;
                if ((align & anyRight) != 0)
                    result = StringAlignment.Far;
                else if ((align & anyCenter) != 0)
                    result = StringAlignment.Center;
                else
                    result = StringAlignment.Near;
                return result;
            }
            static StringAlignment TranslateLineAlignment(ContentAlignment align)
            {
                StringAlignment result;
                if ((align & anyBottom) != 0)
                {
                    result = StringAlignment.Far;
                }
                else if ((align & anyMiddle) != 0)
                {
                    result = StringAlignment.Center;
                }
                else
                {
                    result = StringAlignment.Near;
                }
                return result;
            }
            static StringFormat StringFormatForAlignment(ContentAlignment align)
            {
                StringFormat output = new StringFormat();
                output.Alignment = TranslateAlignment(align);
                output.LineAlignment = TranslateLineAlignment(align);
                return output;
            }
            public static StringFormat CreateStringFormat(SansationRoundButton ctl, ContentAlignment textAlign, bool showEllipsis, bool useMnemonic)
            {
                StringFormat stringFormat = StringFormatForAlignment(textAlign);
                // Adjust string format for Rtl controls
                if (ctl.RightToLeft == RightToLeft.Yes)
                {
                    stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                }
                if (showEllipsis)
                {
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    stringFormat.FormatFlags |= StringFormatFlags.LineLimit;
                }
                if (!useMnemonic)
                {
                    stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                }
                else if (ctl.ShowKeyboardCues)
                {
                    stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                }
                else
                {
                    stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
                }
                if (ctl.AutoSize)
                {
                    stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                }
                return stringFormat;
            }
        }
    }
