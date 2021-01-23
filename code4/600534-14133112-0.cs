    Dim Command As New SqlCommand(_
            "insert into hilmarc_cem_items " & _
            "(CEMID, " & _
            "ItemCode, " & _
            "UnitPrice, " & _
            "Quantity, " & _
            "UOM) ", Connection)     
    Dim ItemCodes() As String = Request.Form.GetValues("ItemCode")
    Dim UnitPrices() As String = Request.Form.GetValues("UnitPrice")
    Dim Quantities() As String = Request.Form.GetValues("Quantity")
    Dim UOMs() As String = Request.Form.GetValues("UOM")
    'Prepare query, do not execute yet!'
    For Counter = 0 To ItemCodes.Length - 1
        Command.CommandText &= "select @CEMID, @ItemCode" & Counter & ", @UnitPrice" & Counter & ", @Quantity" & Counter & ", @UOM" & Counter & " "
        Command.Parameters.Add("@ItemCode" & Counter, Data.SqlDbType.NVarChar).Value = ItemCodes(Counter)
        Command.Parameters.Add("@Quantity" & Counter, Data.SqlDbType.Decimal).Value = Quantities(Counter)
        Command.Parameters.Add("@UOM" & Counter, Data.SqlDbType.NVarChar).Value = UOMs(Counter)
        Command.Parameters.Add("@UnitPrice" & Counter, Data.SqlDbType.Decimal).Value = UnitPrices(Counter)
        If Not Counter = ItemCodes.Length - 1 Then
            Command.CommandText &= "union all "
        Else
            Command.CommandText &= ";"
        End If
    Next
    'After the preparation, execute the query'
    Connection.Open()
    Command.ExecuteNonQuery()
