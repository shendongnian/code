    directly copy this code in a class called "Printing" and Call the "Run" method with your reportviewer name as parameter. Example obj.Run(reportviewer1);
    
    ////////////////////////////////////////////////////////////////////////////////////
    using System;
    using System.IO;
    using System.Data;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Microsoft.Reporting.WinForms;
    
    
    class Printing
    {
    private int m_currentPageIndex;
    private IList m_streams;
     
    
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
     
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"
                EMF
                8.5in
                11in
                0.25in
                0.25in
                0.25in
                0.25in
            ";
            Warning[] warnings;
            m_streams = new List();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
     
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);
     
            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
     
            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
     
            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);
     
            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex &lt; m_streams.Count);
        }
     
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
     
        public void Run(ReportViewer rpt)
        {
            Export(rpt.LocalReport);
            Print();
        }
     
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }
