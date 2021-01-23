    Option Strict On
    Option Explicit On
    
    Imports System.IO
    Imports iTextSharp.text
    Imports iTextSharp.text.pdf
    
    Public Class Form1
    
        Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ''//Test file that we'll create
            Dim TestFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestFile.pdf")
            ''//Standard PDF setup, change as needed for your stream type
            Using FS As New FileStream(TestFile, FileMode.Create, FileAccess.Write, FileShare.None)
                Using Doc As New Document(PageSize.LETTER)
                    Using writer = PdfWriter.GetInstance(Doc, FS)
                        ''//Bind our custom event handler to our writer object
                        writer.PageEvent = New CustomPageEventHandler()
                        Doc.Open()
    
                        ''//Add text on page 1
                        Doc.Add(New Paragraph("Page 1"))
                        ''//Add a new page
                        Doc.NewPage()
                        ''//Add text on page 2
                        Doc.Add(New Paragraph("Page 2"))
    
                        Doc.Close()
                    End Using
                End Using
            End Using
    
            Me.Close()
        End Sub
        Public Class CustomPageEventHandler
            Inherits iTextSharp.text.pdf.PdfPageEventHelper
            ''//This will get called whenever a new page gets added to the document
            Public Overrides Sub OnStartPage(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document)
                ''//Pre-calculate the Y coordinates for use later
                Dim yBot = document.PageSize.Height - 300
                Dim yTop = yBot + 200
    
                ''//For the left margin we'll use the ColumnText object
                Dim CT As New ColumnText(writer.DirectContent)
                ''//Create a single column object bound to our margin and using the y coordinates from above
                CT.SetSimpleColumn(0, yBot, document.LeftMargin, yTop)
                ''//Add a simple paragraph
                CT.AddElement(New Paragraph("This goes in the margin"))
                ''//Draw the text
                CT.Go()
    
    
                ''//For the right margin we'll draw the text manually
                ''//Grab the raw canvas
                Dim cb = writer.DirectContent
                ''//Store the current graphics state so that we can restore it later
                cb.SaveState()
    
                ''//Flag that we're begining text
                cb.BeginText()
                ''//Set a font and size to draw with
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED), 8)
                ''//Set a color for the text
                cb.SetColorFill(BaseColor.RED)
                ''//Draw the text at a specific x,y coordinate. NOTE: These commands assume do not break text for you automatically
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "right margin", document.PageSize.Width - document.RightMargin, yTop, 0)
                ''//Flag that we're doing with our text
                cb.EndText()
    
                ''//Restore the graphics state to whatever it was before we started messing with it
                cb.RestoreState()
    
    
            End Sub
        End Class
    End Class
