    Private Function CellColor(ByVal cell As IXLCell, ByVal wb As XLWorkbook) As Drawing.Color
        Select Case cell.Style.Fill.BackgroundColor.ColorType
            Case XLColorType.Color
                Return cell.Style.Fill.BackgroundColor.Color
            Case XLColorType.Theme
                Select Case cell.Style.Fill.BackgroundColor.ThemeColor
                    Case XLThemeColor.Accent1
                        Return wb.Theme.Accent1.Color
                    Case XLThemeColor.Accent2
                        Return wb.Theme.Accent2.Color
                    ...
                End Select
        End Select
