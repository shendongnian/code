    'Create two header objects as ColumnHeader Class
    Dim header1, header2 As ColumnHeader
    'Construcción de los objetos header
    header1 = New ColumnHeader
    header1.Text = "ID"
    header1.TextAlign = HorizontalAlignment.Right
    header1.Width = 10
    header2 = New ColumnHeader
    header2.Text = "Combinaciones a Procesar"
    header2.TextAlign = HorizontalAlignment.Left
    header2.Width = 10
    
    'Add two columns using your news headers objects 
    ListView.Columns.Add(header1)
    ListView.Columns.Add(header2)
    'Fill three rows of data, for each column
    ListView.Items.Add(New ListViewItem({"A1", "B1"}))
    ListView.Items.Add(New ListViewItem({"A2", "B2"}))
    ListView.Items.Add(New ListViewItem({"A3", "B3"}))
    'Change the size of each column
    Dim headsz1, headsz2 As Integer
    SelectionInTable.ListView.AutoResizeColumn(0,             ColumnHeaderAutoResizeStyle.HeaderSize)
    SelectionInTable.ListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)
    headsz1 = header1.Width
    headsz2 = header2.Width
    SelectionInTable.ListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
    SelectionInTable.ListView.AutoResizeColumn(1,     ColumnHeaderAutoResizeStyle.ColumnContent)
    headsz1 = Math.Max(headsz1, header1.Width)
    headsz2 = Math.Max(headsz2, header2.Width)
    header1.Width = headsz1
    header2.Width = headsz2
