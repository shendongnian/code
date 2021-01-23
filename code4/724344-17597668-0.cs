    'create tablix - manually
    Dim tablixRFoo As New RdlObjectModel.Tablix With {.Top = New RdlObjectModel.ReportSize("0.56875in"), .Width = New RdlObjectModel.ReportSize("0.5in")}
    tablixRFoo.Name = "tablix1"
    tablixRFoo.DataSetName = dsRFoo.Name
    'add tablix columns
        tablixRFoo.TablixBody.TablixColumns.Add(New RdlObjectModel.TablixColumn With {.Width = New RdlObjectModel.ReportSize(2.0)})
        tablixRFoo.TablixBody.TablixColumns.Add(New RdlObjectModel.TablixColumn With {.Width = New RdlObjectModel.ReportSize(2.0)})
        tablixRFoo.TablixBody.TablixColumns.Add(New RdlObjectModel.TablixColumn With {.Width = New RdlObjectModel.ReportSize(2.0)})
        tablixRFoo.TablixBody.TablixColumns.Add(New RdlObjectModel.TablixColumn With {.Width = New RdlObjectModel.ReportSize(2.0)})
        tablixRFoo.TablixBody.TablixColumns.Add(New RdlObjectModel.TablixColumn With {.Width = New RdlObjectModel.ReportSize(2.0)})
...
    Dim tColHeirarcy = New RdlObjectModel.TablixHierarchy
    Dim tRowHeirarcy = New RdlObjectModel.TablixHierarchy
