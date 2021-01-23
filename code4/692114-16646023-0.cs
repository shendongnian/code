    OleDbCommand cmd = new OleDbCommand("UPDATE Available SET ProductType = '" + newAvailable.ProductType + "', Brand = '"+ newAvailable.Brand + "', Model = '" + newAvailable.Model + "', SerialNo = '" + newAvailable.SerialNo + "', Remarks = '" + newAvailable.Remarks + "', RAM = '" + newAvailable.RAM + "', HDD = '" + newAvailable.HDD + "', ODD = '" + newAvailable.ODD + "', VideoCard = '" + newAvailable.VideoCard + "', PS = '" + newAvailable.PS + "'  WHERE AvailableID = "+oldAvailable.AvailableID, cnn);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
