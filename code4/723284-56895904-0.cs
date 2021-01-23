this.rtb.CursorPositionChanged += 
    new System.EventHandler(this.rtb_CursorPositionChanged);
this.rtb.SelectionChanged += 
    new System.EventHandler(this.rtb_SelectionChanged);
.
.
.
private void rtb_CursorPositionChanged(object sender, System.EventArgs e)
{
    int line = rtb.CurrentLine;
    int col = rtb.CurrentColumn;
    int pos = rtb.CurrentPosition;
    
    statusBar.Text = "Line " + line + ", Col " + col + 
                     ", Position " + pos;
}
private void rtb_SelectionChanged(object sender, System.EventArgs e)
{
    int start = rtb.SelectionStart;
    int end = rtb.SelectionEnd;
    int length = rtb.SelectionLength;
    
    statusBar.Text = "Start " + start + ", End " + end + 
                     ", Length " + length;
}
namespace Nik.UserControls
{
    public class RicherTextBox2 : System.Windows.Forms.RichTextBox
    {
        public event EventHandler CursorPositionChanged;
        
        protected virtual void OnCursorPositionChanged( EventArgs e )
        {
            if ( CursorPositionChanged != null )
                CursorPositionChanged( this, e );
        }
        protected override void OnSelectionChanged( EventArgs e )
        {
            if ( SelectionLength == 0 )
                OnCursorPositionChanged( e );
            else
                base.OnSelectionChanged( e );
        }
            
        public int CurrentColumn
        {
            get { return CursorPosition.Column( this, SelectionStart ); }
        }
        public int CurrentLine
        {
            get { return CursorPosition.Line( this, SelectionStart ); }
        }
        public int CurrentPosition
        {
            get { return this.SelectionStart; }
        }
        public int SelectionEnd
        {
            get { return SelectionStart + SelectionLength; }
        }
    }
    
    internal class CursorPosition
    {
        [System.Runtime.InteropServices.DllImport("user32")] 
        public static extern int GetCaretPos(ref Point lpPoint);
        private static int GetCorrection(RichTextBox e, int index)
        {
            Point pt1 = Point.Empty;
            GetCaretPos(ref pt1);
            Point pt2 = e.GetPositionFromCharIndex(index);
            if ( pt1 != pt2 )
                return 1;
            else
                return 0;
        }
        public static int Line( RichTextBox e, int index )
        {
             int correction = GetCorrection( e, index );
             return e.GetLineFromCharIndex( index ) - correction + 1;
        }
        public static int Column( RichTextBox e, int index1 )
        {
             int correction = GetCorrection( e, index1 );
             Point p = e.GetPositionFromCharIndex( index1 - correction );
             if ( p.X == 1 )
                 return 1;
             p.X = 0;
             int index2 = e.GetCharIndexFromPosition( p );
             int col = index1 - index2 + 1;
             return col;
         }
    }
}
