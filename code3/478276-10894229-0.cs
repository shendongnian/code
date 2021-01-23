    namespace David.PDFTest
    {
        public partial class PDFView : PDFViewCtrl
        {
            protected override void OnMouseDown(MouseEventArgs e)
            {   
                var bm = GetDoc().GetFirstBookmark();
                while ( bm!=null )
                {
                    Trace.WriteLine(bm.GetTitle());
                    bm = bm.GetNext();
                }
            }
        }
    }
