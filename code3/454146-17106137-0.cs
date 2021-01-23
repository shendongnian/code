        Dim stream As New IO.MemoryStream(System.Text.ASCIIEncoding.[Default].GetBytes("{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}}{\colortbl ;\red255\green255\blue255;}\viewkind4\uc1\pard\cf1\f0\fs29 RIGO NOTIZIA 1 TESTO TESTO TESTO\fs17\par}"))
        Dim RichTextBox1 As New RichTextBox()
        RichTextBox1.Selection.Load(stream, DataFormats.Rtf)
        Dim pr As New System.Windows.Documents.Paragraph()
        pr = RichTextBox1.Document.Blocks(0)
        Dim tre As Int32 = pr.Inlines.Count
        TextBlock1.Inlines.Add(pr.Inlines(0))
