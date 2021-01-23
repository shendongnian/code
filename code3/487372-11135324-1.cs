    int ndx = rdr.GetOrdinal("<ColumnName>");
                if(!rdr.IsDBNull(ndx))
               {
                long size = rdr.GetBytes(ndx, 0, null, 0, 0);  //get the length of data
                byte[] values = new byte[size];
    
                int bufferSize = 1024;
                long bytesRead = 0;
                int curPos = 0;
    
                while (bytesRead < size)
                {
                    bytesRead += rdr.GetBytes(ndx, curPos, values, curPos, bufferSize);
                    curPos += bufferSize;
                }
               }
