        Try
            Dim cmbRespuesas As ASPxComboBox = GvEncuesta.FindRowCellTemplateControl(e.VisibleIndex, Nothing, "ASPxCmbRespuestas")
            cmbRespuesas.IncrementalFilteringMode = IncrementalFilteringMode.Contains
            cmbRespuesas.Visible = True
            cmbRespuesas.DataSource = wcfCap.RetrieveRespuestaEncuestaxEstado(1)
            cmbRespuesas.ValueField = "Cod_Respuesta"
            cmbRespuesas.TextField = "Nombre_Respuesta"
            cmbRespuesas.DataBindItems()
        Catch ex As Exception
        End Try
    End Sub
