    Protected Sub SqlDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles SqlDataSource1.Inserting
            Dim FU As New FileUpload
            FU = DetailsView1.FindControl("fileupload1")    
            Using fs As Stream = FU.PostedFile.InputStream
                Using br As New BinaryReader(fs)
                    Dim tc As SqlParameter
                    tc = New SqlParameter("@tc", SqlDbType.VarBinary)
                    Dim bytes As Byte() = br.ReadBytes(DirectCast(fs.Length, Long))
                    tc.Value = bytes
                    e.Command.Parameters.Add(tc)
    
                End Using
            End Using       
        End Sub
