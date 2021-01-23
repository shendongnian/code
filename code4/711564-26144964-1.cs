    Dim DTDep As DataView
    Private Sub CargarUbicacion()
            Dim adapter As New SqlCeDataAdapter
            Dim comando As SqlCeCommandBuilder
            Dim Datos As New DataSet
            Dim Str As String
            Dim Consult As String
            
    
            Try
                Str = "select idUbicacion,Descripcion from Ubicacion order by Descripcion"
    
                Dim Cn As SqlCeConnection = GetConnection()
                adapter = New SqlCeDataAdapter(Str, Cn)
                adapter.Fill(Dset, "UBICACION")
                DTDep = Dset.Tables("UBICACION").DefaultView
                Me.cmbUbicaciones.DataSource = DTDep
                Me.cmbUbicaciones.DisplayMember = "Descripcion"
            Catch ex As Exception
                MsgBox("Error al cargar ubicaciones" & ex.Message)
            End Try
        End Sub
    this ?
      Private Sub cmbUbicacion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUbicacion.SelectedValueChanged
           
    
            Me.lblIiUbiFin.Text = Convert.ToInt32(Me.cmbUbicacion.SelectedValue).ToString
    
        End Sub
