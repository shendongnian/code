	Imports System.ComponentModel
	Imports System.ComponentModel.Design
	Imports System.Drawing.Printing
	Namespace Windows.Forms
	    <ToolboxBitmap(GetType(PrintDocument))> _
	    Public Class DataGridViewPrintDocument
		Inherits PrintDocument
	#Region " ColumnInfo "
		Private NotInheritable Class ColumnInfo
		    Public ReadOnly Left As Integer
		    Public ReadOnly Width As Integer
		    Public ReadOnly Type As Type
		    Public ReadOnly DisplayIndex As Integer
		    Public ReadOnly HeaderText As String
		    Public ReadOnly InheritedStyle As DataGridViewCellStyle
		    Public ReadOnly ColumnName As String
		    Public Sub New(ByVal left As Integer, ByVal width As Integer, ByVal column As DataGridViewColumn)
			Me.Left = left
			Me.Width = width
			Me.Type = column.GetType
			Me.DisplayIndex = column.DisplayIndex
			Me.HeaderText = column.HeaderText
			Me.InheritedStyle = column.InheritedStyle
			Me.ColumnName = column.Name
		    End Sub
		End Class
	#End Region
	#Region " Sections "
		'DESIGN - add adornments property then print adornments
		'   this can take care of header, footer, watermark, and anything else
		'   adornments can be a base class with derived
		'       page info adornment
		'       date adornment
		'       document title adornment
		'       image adornment
		'       and so on
		'
		'   as currently implemented, adornments are for header and footer sections
		'   so, i changed the adornment class to the section class
		'
		Private NotInheritable Class Section
		    Implements IDisposable
	#Region " IDisposable Implementation "
		    Private _disposed As Boolean
		    Private Sub Dispose(ByVal disposing As Boolean)
			If Not _disposed Then
			    If disposing Then
				_stringFormat.Dispose()
				_font.Dispose()
			    End If
			    _stringFormat = Nothing
			    _font = Nothing
			    _text = Nothing
			    _disposed = True
			End If
		    End Sub
		    Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
			GC.SuppressFinalize(Me)
		    End Sub
	#End Region
		    Private _text As String
		    Private _bounds As Rectangle
		    Private _font As Font
		    Private _stringFormat As StringFormat
		    Public Sub New(ByVal type As SectionType, ByVal text As String, ByVal font As Font, ByVal bounds As Rectangle, ByVal rtl As RightToLeft)
			_text = text
			_font = DirectCast(font.Clone, System.Drawing.Font)
			_bounds = bounds
			Dim iAlignment As DataGridViewContentAlignment = CType([Enum].Parse(GetType(DataGridViewContentAlignment), type.ToString), DataGridViewContentAlignment)
			_stringFormat = GatherStringFormat(iAlignment, DataGridViewTriState.False, rtl)
		    End Sub
		    Public Property Text() As String
			Get
			    Return _text
			End Get
			Set(ByVal value As String)
			    _text = value
			End Set
		    End Property
		    Public ReadOnly Property Bounds() As Rectangle
			Get
			    Return _bounds
			End Get
		    End Property
		    Public ReadOnly Property font() As Font
			Get
			    Return _font
			End Get
		    End Property
		    Public ReadOnly Property StringFormat() As StringFormat
			Get
			    Return _stringFormat
			End Get
		    End Property
		End Class
		Private Enum SectionType
		    TopLeft
		    TopCenter
		    TopRight
		    BottomLeft
		    BottomCenter
		    BottomRight
		End Enum
	#End Region
	#Region " IDisposable Implementation "
		Private _disposed As Boolean
		Private Sub PerformDispose(ByVal o As IDisposable)
		    If o IsNot Nothing Then
			o.Dispose()
		    End If
		End Sub
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		    Try
			If Not _disposed Then
			    If disposing Then
				PerformDispose(_button)
				PerformDispose(_checkbox)
				PerformDispose(_picture)
				PerformDispose(_panel)
				If _cachedFormats IsNot Nothing Then
				    For Each oPageInfo As Section In _cachedFormats.Values
					oPageInfo.Dispose()
				    Next
				End If
			    End If
			    If _columns IsNot Nothing Then
				_columns.Clear()
			    End If
			    _columns = Nothing
			    If _cachedFormats IsNot Nothing Then
				_cachedFormats.Clear()
			    End If
			    _cachedFormats = Nothing
			    _button = Nothing
			    _checkbox = Nothing
			    _picture = Nothing
			    _panel = Nothing
			    _dataGrid = Nothing
			    _disposed = True
			End If
		    Finally
			MyBase.Dispose(disposing)
		    End Try
		End Sub
	#End Region
		Private _panel As Panel
		Private _button As Button
		Private _checkbox As CheckBox
		Private _picture As New PictureBox
		Private _columns As List(Of ColumnInfo)
		Private _cachedFormats As Dictionary(Of SectionType, Section)
		Private _rowPrintingIndex As Integer
		Private _rowCount As Integer
		Private _newPage As Boolean
		Private _pageNo As Integer
		Private _isPageCounting As Boolean
		Private _pageCount As Integer
		Private _dataGrid As DataGridView
		Private _totalColumnsWidth As Integer
		Public Sub New()
		    Me.New(Nothing, False)
		End Sub
		Private Sub New(ByVal dataGrid As DataGridView, ByVal isPageCounting As Boolean)
		    MyBase.New()
		    _isPageCounting = isPageCounting
		    _dataGrid = dataGrid
		    If Not Me.IsPageCounting Then
			'using controls instead of the renderer classes
			'this allows for painting with the correct background and transparency colors
			_button = New Button
			_checkbox = New CheckBox
			_picture = New PictureBox
			'force creation of control handles
			'   this allows drawing transparent backgrounds
			'   and eliminates the black borders when using 'draw to bitmap'
			'   note, the check box does not need a parent control
			_panel = New Panel
			_panel.BackColor = SystemColors.Window
			_panel.Controls.AddRange(New Control() {_button, _picture})
			_panel.CreateControl()
		    End If
		End Sub
		<DefaultValue(CType(Nothing, String))> _
		Public Property DataGrid() As DataGridView
		    Get
			Return _dataGrid
		    End Get
		    Set(ByVal value As DataGridView)
			_dataGrid = value
		    End Set
		End Property
		<Browsable(False)> _
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property IsPageCounting() As Boolean
		    Get
			Return _isPageCounting
		    End Get
		    Set(ByVal value As Boolean)
			_isPageCounting = value
		    End Set
		End Property
		Private Sub InitializeSections()
		    '   document name in top left corner
		    '   date in bottom left corner
		    '   pages in bottom right corner
		    Dim oBounds As Rectangle
		    Dim oMarginBounds As Rectangle = GatherDefaultMarginBounds(Me.DefaultPageSettings)
		    _cachedFormats = New Dictionary(Of SectionType, Section)
		    'hard-coded to half inch from edge until there is support for header margin
		    oBounds = Rectangle.FromLTRB(oMarginBounds.Left, Me.DefaultPageSettings.Bounds.Top + 50, oMarginBounds.Right, Me.DefaultPageSettings.Bounds.Top + 100)
		    _cachedFormats.Add(SectionType.TopLeft, New Section(SectionType.TopLeft, Me.DocumentName, New Font(Me.DataGrid.Font, FontStyle.Bold Or FontStyle.Italic), oBounds, Me.DataGrid.RightToLeft))
		    'hard-coded to half inch from edge until there is support for header margin
		    oBounds = Rectangle.FromLTRB(oMarginBounds.Left, Me.DefaultPageSettings.Bounds.Bottom - 100, oMarginBounds.Right, Me.DefaultPageSettings.Bounds.Bottom - 50)
		    Dim sDate As String = String.Format("{0}", Now.ToLongDateString)
		    _cachedFormats.Add(SectionType.BottomLeft, New Section(SectionType.BottomLeft, sDate, Me.DataGrid.Font, oBounds, Me.DataGrid.RightToLeft))
		    _cachedFormats.Add(SectionType.BottomRight, New Section(SectionType.BottomRight, Nothing, Me.DataGrid.Font, oBounds, Me.DataGrid.RightToLeft))
		End Sub
		Protected Overrides Sub OnBeginPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
		    If Me.DataGrid Is Nothing Then
			'nothing to do
			e.Cancel = True
			Exit Sub
		    End If
		    _columns = New List(Of ColumnInfo)
		    _rowPrintingIndex = 0
		    _newPage = True
		    _pageNo = 1
		    _rowCount = Me.DataGrid.RowCount
		    Dim oMarginBounds As Rectangle = GatherDefaultMarginBounds(Me.DefaultPageSettings)
		    Dim nLeft As Integer = oMarginBounds.Left
		    Dim nWidth As Integer
		    If Not Me.IsPageCounting Then
			InitializeSections()
			Using g As Graphics = Me.PrinterSettings.CreateMeasurementGraphics
			    _totalColumnsWidth = Me.DataGrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)
			    Dim oColumn As DataGridViewColumn = Me.DataGrid.Columns.GetFirstColumn(DataGridViewElementStates.Visible)
			    Do Until oColumn Is Nothing
				nWidth = CInt(System.Math.Floor(oMarginBounds.Width * oColumn.Width / _totalColumnsWidth))
				_columns.Add(New ColumnInfo(nLeft, nWidth, oColumn))
				nLeft += nWidth
				oColumn = Me.DataGrid.Columns.GetNextColumn(oColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None)
			    Loop
			End Using
		    End If
		    MyBase.OnBeginPrint(e)
		End Sub
		Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
		    Dim iRowTop As Integer = e.MarginBounds.Top + Me.DataGrid.ColumnHeadersHeight
		    Do
			Dim oRow As DataGridViewRow = Me.DataGrid.Rows(_rowPrintingIndex)
			If oRow.IsNewRow Then
			    Exit Do
			End If
			If iRowTop + oRow.Height >= e.MarginBounds.Bottom Then
			    'we get here when printing all pages, except the last page
			    e.HasMorePages = True
			    If Not Me.IsPageCounting Then
				OnPaintPageFooter(e)
			    End If
			    _newPage = True
			    _pageNo += 1
			    MyBase.OnPrintPage(e)
			    Exit Sub
			Else
			    If Not Me.IsPageCounting Then
				If _newPage Then
				    OnPaintPageHeader(e)
				    OnPaintColumnHeaders(e)
				    _newPage = False
				End If
				For Each oColInfo As ColumnInfo In _columns
				    Dim oCellFace As Rectangle
				    Dim oPaintEventArgs As DataGridViewPrintDocumentPaintEventArgs
				    Dim oCell As DataGridViewCell = oRow.Cells(oColInfo.ColumnName)
				    Debug.Assert(oCell IsNot Nothing, "Fix iT! We must find the cell!")
				    'cell bounds, including border created by the grid lines
				    oCellFace = New Rectangle( _
					oColInfo.Left, _
					iRowTop, _
					oColInfo.Width, _
					oRow.Height)
				    'paint cell grid lines
				    oPaintEventArgs = New DataGridViewPrintDocumentPaintEventArgs(e.Graphics, oCellFace, oCell)
				    OnPaintCellBorder(oPaintEventArgs)
				    'cell bounds, excluding cell grid lines
				    oCellFace.Inflate(-1, -1)
				    If oColInfo.Type Is GetType(DataGridViewTextBoxColumn) Then
					OnPaintTextBoxCell(oPaintEventArgs)
				    ElseIf oColInfo.Type Is GetType(DataGridViewLinkColumn) Then
					OnPaintLinkCell(oPaintEventArgs)
				    ElseIf oColInfo.Type Is GetType(DataGridViewComboBoxColumn) Then
					OnPaintComboBoxCell(oPaintEventArgs)
				    ElseIf oColInfo.Type Is GetType(DataGridViewButtonColumn) Then
					OnPaintButtonCell(oPaintEventArgs)
				    ElseIf oColInfo.Type Is GetType(DataGridViewCheckBoxColumn) Then
					OnPaintCheckBoxCell(oPaintEventArgs)
				    ElseIf oColInfo.Type Is GetType(DataGridViewImageColumn) Then
					OnPaintImageCell(oPaintEventArgs)
				    Else
					OnPaintCustomCell(oPaintEventArgs)
				    End If
				Next
			    End If
			End If
			iRowTop += oRow.Height
			_rowPrintingIndex += 1
		    Loop While (_rowPrintingIndex < _rowCount)
		    'we get here on the last page
		    If Not Me.IsPageCounting Then
			OnPaintPageFooter(e)
		    End If
		    MyBase.OnPrintPage(e)
		End Sub
		Protected Overrides Sub OnEndPrint(ByVal e As System.Drawing.Printing.PrintEventArgs)
		    If _columns IsNot Nothing Then
			_columns.Clear()
		    End If
		    _columns = Nothing
		    _picture.Image = Nothing
		    If _cachedFormats IsNot Nothing Then
			For Each oPageInfo As Section In _cachedFormats.Values
			    oPageInfo.Dispose()
			Next
			_cachedFormats.Clear()
		    End If
		    _cachedFormats = Nothing
		    MyBase.OnEndPrint(e)
		End Sub
	#Region " OnPaint... Implementations "
		Protected Overridable Sub OnPaintTextBoxCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    If Len(e.Cell.FormattedValue) > 0 Then
			Dim oBounds As Rectangle = GatherContentBounds(e.ClipRectangle, e.Cell.InheritedStyle.Padding)
			Using oBrush As New SolidBrush(e.Cell.InheritedStyle.ForeColor)
			    Using oStringFormat As StringFormat = GatherStringFormat(e.Cell.InheritedStyle.Alignment, e.Cell.InheritedStyle.WrapMode, Me.DataGrid.RightToLeft)
				e.Graphics.DrawString(CStr(e.Cell.FormattedValue), e.Cell.InheritedStyle.Font, oBrush, oBounds, oStringFormat)
			    End Using
			End Using
		    End If
		End Sub
		Protected Overridable Sub OnPaintLinkCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    Dim oLinkCell As DataGridViewLinkCell = DirectCast(e.Cell, DataGridViewLinkCell)
		    If Len(e.Cell.FormattedValue) > 0 Then
			Dim oBounds As Rectangle = GatherContentBounds(e.ClipRectangle, e.Cell.InheritedStyle.Padding)
			Dim oLinkColor As Color = DirectCast(IIf(oLinkCell.LinkVisited, oLinkCell.VisitedLinkColor, oLinkCell.LinkColor), Color)
			Using oBrush As New SolidBrush(oLinkColor)
			    Using oFont As New Font(e.Cell.InheritedStyle.Font, FontStyle.Underline)
				Using oStringFormat As StringFormat = GatherStringFormat(e.Cell.InheritedStyle.Alignment, e.Cell.InheritedStyle.WrapMode, Me.DataGrid.RightToLeft)
				    e.Graphics.DrawString(CStr(e.Cell.FormattedValue), oFont, oBrush, oBounds, oStringFormat)
				End Using
			    End Using
			End Using
		    End If
		End Sub
		Protected Overridable Sub OnPaintComboBoxCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    OnPaintTextBoxCell(e)
		End Sub
		Protected Overridable Sub OnPaintButtonCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    If Len(e.Cell.FormattedValue) > 0 Then
			Dim oBounds As Rectangle = GatherContentBounds(e.ClipRectangle, e.Cell.InheritedStyle.Padding)
			Dim oFace As New Rectangle(oBounds.X + 1, oBounds.Y + 1, oBounds.Width - 2, oBounds.Height - 3)
			_button.Size = oFace.Size
			_button.Text = CStr(e.Cell.FormattedValue)
			Using oBitmap As New Bitmap(oFace.Width, oFace.Height)
			    _button.DrawToBitmap(oBitmap, New Rectangle(0, 0, oFace.Width, oFace.Height))
			    e.Graphics.DrawImageUnscaled(oBitmap, oFace)
			End Using
		    End If
		End Sub
		Protected Overridable Sub OnPaintCheckBoxCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    _checkbox.Checked = CBool(e.Cell.FormattedValue)
		    Dim iCheckBoxState As VisualStyles.CheckBoxState
		    If _checkbox.Checked Then
			iCheckBoxState = VisualStyles.CheckBoxState.UncheckedNormal
		    Else
			iCheckBoxState = VisualStyles.CheckBoxState.UncheckedNormal
		    End If
		    Using oControlGraphics As Graphics = _checkbox.CreateGraphics
			_checkbox.Size = CheckBoxRenderer.GetGlyphSize(oControlGraphics, iCheckBoxState)
		    End Using
		    Dim oBounds As Rectangle = GatherContentBounds(e.ClipRectangle, e.Cell.InheritedStyle.Padding)
		    Dim oBoundsCenteredOnCellFace As New Rectangle( _
			 oBounds.Left + ((oBounds.Width - _checkbox.Size.Width) \ 2), _
			 oBounds.Top + ((oBounds.Height - _checkbox.Size.Height) \ 2), _
			 _checkbox.Width, _
			 _checkbox.Height)
		    Using oBitmap As New Bitmap(_checkbox.Width + 1, _checkbox.Height + 1)
			_checkbox.DrawToBitmap(oBitmap, New Rectangle(1, 1, _checkbox.Width, _checkbox.Height))
			e.Graphics.DrawImageUnscaled(oBitmap, oBoundsCenteredOnCellFace)
		    End Using
		End Sub
		Protected Overridable Sub OnPaintImageCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    Dim oImageCell As DataGridViewImageCell = DirectCast(e.Cell, DataGridViewImageCell)
		    Dim oImage As Image = DirectCast(oImageCell.FormattedValue, Image)
		    Dim oBounds As Rectangle = GatherContentBounds(e.ClipRectangle, e.Cell.InheritedStyle.Padding)
		    Dim oFace As New Rectangle( _
			oBounds.X + 1, _
			oBounds.Y + 1, _
			oBounds.Width - 2, _
			oBounds.Height - 4)
		    _picture.Size = oFace.Size
		    Select Case oImageCell.ImageLayout
			Case DataGridViewImageCellLayout.Stretch
			    _picture.SizeMode = PictureBoxSizeMode.StretchImage
			Case DataGridViewImageCellLayout.Normal
			    _picture.SizeMode = PictureBoxSizeMode.CenterImage
			Case DataGridViewImageCellLayout.Zoom
			    _picture.SizeMode = PictureBoxSizeMode.Zoom
			Case Else
			    Debug.Fail("FixiT! We must support all possible image layout values.")
		    End Select
		    _picture.Image = oImage
		    Using oBitmap As New Bitmap(oFace.Width, oFace.Height)
			_picture.DrawToBitmap(oBitmap, New Rectangle(0, 0, oFace.Width, oFace.Height))
			e.Graphics.DrawImageUnscaled(oBitmap, oFace)
		    End Using
		    _picture.Image = Nothing
		End Sub
		Protected Overridable Sub OnPaintCustomCell(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    OnPaintTextBoxCell(e)
		End Sub
		Protected Overridable Sub OnPaintCellBorder(ByVal e As DataGridViewPrintDocumentPaintEventArgs)
		    Using oPen As New Pen(Me.DataGrid.GridColor)
			e.Graphics.DrawRectangle(oPen, e.ClipRectangle)
		    End Using
		End Sub
		Protected Overridable Sub OnPaintPageHeader(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
		    'left section
		    If _cachedFormats.ContainsKey(SectionType.TopLeft) Then
			PaintSection(e.Graphics, _cachedFormats.Item(SectionType.TopLeft))
		    End If
		    'center section
		    If _cachedFormats.ContainsKey(SectionType.TopCenter) Then
			PaintSection(e.Graphics, _cachedFormats.Item(SectionType.TopCenter))
		    End If
		    'right section
		    If _cachedFormats.ContainsKey(SectionType.TopRight) Then
			PaintSection(e.Graphics, _cachedFormats.Item(SectionType.TopRight))
		    End If
		End Sub
		Protected Overridable Sub OnPaintColumnHeaders(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
		    For Each oColInfo As ColumnInfo In _columns
			Dim oColumn As DataGridViewColumn = Me.DataGrid.Columns.Item(oColInfo.ColumnName)
			'header cell bounds, including border created by the grid lines
			Dim oCellFace As Rectangle = New Rectangle(oColInfo.Left, e.MarginBounds.Top, oColInfo.Width, Me.DataGrid.ColumnHeadersHeight)
			e.Graphics.FillRectangle(SystemBrushes.Control, oCellFace)
			Using oPen As New Pen(oColInfo.InheritedStyle.ForeColor)
			    e.Graphics.DrawRectangle(oPen, oCellFace)
			    Using oStringFormat As StringFormat = GatherStringFormat(oColumn.InheritedStyle.Alignment, DataGridViewTriState.False, Me.DataGrid.RightToLeft)
				e.Graphics.DrawString(oColInfo.HeaderText, oColInfo.InheritedStyle.Font, oPen.Brush, oCellFace, oStringFormat)
			    End Using
			End Using
		    Next
		End Sub
		Protected Overridable Sub OnPaintPageFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
		    'left section
		    If _cachedFormats.ContainsKey(SectionType.BottomLeft) Then
			PaintSection(e.Graphics, _cachedFormats.Item(SectionType.BottomLeft))
		    End If
		    'center section
		    If _cachedFormats.ContainsKey(SectionType.BottomCenter) Then
			PaintSection(e.Graphics, _cachedFormats.Item(SectionType.BottomCenter))
		    End If
		    'right section
		    If _cachedFormats.ContainsKey(SectionType.BottomRight) Then
			Dim oSection As Section = _cachedFormats.Item(SectionType.BottomRight)
			oSection.Text = String.Format("{0} of {1}", _pageNo, _pageCount)
			PaintSection(e.Graphics, oSection)
		    End If
		End Sub
	#End Region
		Private Shared Sub PaintSection(ByVal g As Graphics, ByVal section As Section)
		    g.DrawString(section.Text, section.font, SystemBrushes.WindowText, section.Bounds, section.StringFormat)
		End Sub
		Private Shared Function GatherStringFormat(ByVal alignment As DataGridViewContentAlignment, ByVal wrapMode As DataGridViewTriState, ByVal rtl As RightToLeft) As StringFormat
		    Dim oResult As StringFormat = Tools.CreateStringFormat(CType(alignment, ContentAlignment), True, False, rtl, False, False)
		    If wrapMode = DataGridViewTriState.True Then
			oResult.FormatFlags = oResult.FormatFlags Or StringFormatFlags.NoWrap
		    End If
		    Return oResult
		End Function
		''' <summary>
		''' Deflates a rectangle by the specified padding.
		''' </summary>
		Private Shared Function GatherContentBounds(ByVal rect As Rectangle, ByVal padding As Padding) As Rectangle
		    rect.X += padding.Left
		    rect.Y += padding.Top
		    rect.Width -= padding.Horizontal
		    rect.Height -= padding.Vertical
		    Return rect
		End Function
		Private Shared Function GatherDefaultMarginBounds(ByVal pageSettings As PageSettings) As Rectangle
		    Dim oMargins As Margins = pageSettings.Margins
		    Dim oPageBounds As Rectangle = pageSettings.Bounds
		    Return Rectangle.FromLTRB(oMargins.Left, oMargins.Top, oPageBounds.Right - oMargins.Right, oPageBounds.Bottom - oMargins.Bottom)
		End Function
	    End Class
	    Public Class DataGridViewPrintDocumentPaintEventArgs
		Inherits PaintEventArgs
		Public ReadOnly Cell As DataGridViewCell
		Public Sub New(ByVal graphics As Graphics, ByVal clipRect As Rectangle, ByVal cell As DataGridViewCell)
		    MyBase.New(graphics, clipRect)
		    Me.Cell = cell
		End Sub
	    End Class
	End Namespace
