    using System;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using Microsoft.Office.Interop.Word;
    using Microsoft.VisualBasic.Devices;
    using Page=System.Web.UI.Page;
    
    public partial class DefaultPage : Page {
        private Application m_word;
        private int m_i;
    
        protected void Page_Load(object sender, EventArgs e) {
            object missing = Type.Missing;
            object fileName = "C:\\Test.docx";
            m_word = new Application();
            m_word.Documents.Open(ref fileName,
                                  ref missing, ref missing, ref missing, ref missing, ref missing,
                                  ref missing, ref missing, ref missing, ref missing, ref missing,
                                  ref missing, ref missing, ref missing, ref missing, ref missing);
    
            try {
                for (int i = 0; i < m_word.ActiveDocument.InlineShapes.Count; i++) {
                    m_i = i;
                    Thread thread = new Thread(CopyFromClipboardInlineShape);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
                for (int i = 0; i < m_word.ActiveDocument.Shapes.Count; i++) {
                    m_i = i;
                    Thread thread = new Thread(CopyFromClipboardShape);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
            }
            finally {
                object save = false;
                m_word.Quit(ref save, ref missing, ref missing);
                m_word = null;
            }
        }
    
        protected void CopyFromClipboardInlineShape() {
            InlineShape inlineShape = m_word.ActiveDocument.InlineShapes[m_i];
            inlineShape.Select();
            m_word.Selection.Copy();
            Computer computer = new Computer();
            Image img = computer.Clipboard.GetImage();
            /*...*/
        }
    
        protected void CopyFromClipboardShape() {
            object missing = Type.Missing;
            object i = m_i + 1;
            Shape shape = m_word.ActiveDocument.Shapes.get_Item(ref i);
            shape.Select(ref missing);
            m_word.Selection.Copy();
            Computer computer = new Computer();
            Image img = computer.Clipboard.GetImage();
            /*...*/
        }
    }
