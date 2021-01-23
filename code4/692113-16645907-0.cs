    var cmd = new OleDbCommand
    {
        Connection = cnn,
        CommandType = CommandType.Text,
        CommandText = "UPDATE Available SET ProductType = ?, Brand = ?, Model = ?, SerialNo = ?, Remarks = ?, RAM = ?, ODD = ?, VideoCard = ?, PS = ?  WHERE AvailableID = ?"
    };
    cmd.Parameters.Add(new OleDbParameter {Value = newAvailable.ProductType});
    cmd.Parameters.Add(new OleDbParameter {Value = newAvailable.Brand});
    // add the other parameters ...
