        string insertSql = string.Format("insert into \"{0}\" (sbfotoint,NmArqBlob) values (?,?);", this.table);
    
            using (var command = new IfxCommand(insertSql, this.connection))
            {
                this.connection.Open();
                SetRole();
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(new IfxParameter()).Value = CreateIfxBlob(entidade.SBlob);
                command.Parameters.Add(new IfxParameter()).Value = entidade.NomeArquivo;
                command.ExecuteNonQuery();
                this.connection.Close();
            }
    
    private IfxBlob CreateIfxBlob(byte[] data)
        {
            IfxBlob blob = connection.GetIfxBlob(this.table, "sbfotoint");
            blob.Open(IfxSmartLOBOpenMode.ReadWrite);
            blob.Write(data);
            blob.Close();
            return blob;
        }
