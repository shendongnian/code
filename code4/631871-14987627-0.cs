                cmd.Transaction = trn;
                cmd.CommandText = "UPDATE ATTACHMENTS_CONTENT SET ATTACHMENT = @BYTES Where ID=@ID";
                // 2. define parameters used in command object
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@BYTES";
                param.Value = bytes;
                cmd.Parameters.Add(param);
                // 2. define parameters used in command object
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ID";
                param2.Value = gAttachmentContentID;
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();
            }
