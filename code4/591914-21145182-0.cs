        public static ChunkedXmlInsert(XmlItem item)
        {
            int bufferSize = 65536;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                CreateTempTable(connection);
                int position = 0;
                using (StreamReader textStream = File.OpenText(item.XmlFileName))
                {
                    char[] buffer = new char[bufferSize];
                    int length = textStream.Read(buffer, position, buffer.Length);
                    long id = InsertFirstBlock(connection, new string(buffer, 0, length));
                    
                    while (textStream.EndOfStream == false)
                    {
                        position += length;
                        length = textStream.Read(buffer, position, buffer.Length);
                        AppendBlock(connection, id, new string(buffer, 0, length));
                    }
                }
                CopyRecordFromTemp(connection, id);
            }
        }
        private static void CreateTempTable(SqlConnection connection)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"CREATE TABLE #TBL_XML (
                                                                  [XmlFileID] [BIGINT] IDENTITY (1, 1) NOT NULL PRIMARY KEY,
                                                                  [FileName] [NVARCHAR](500) NULL,
                                                                  [XmlData] [NVARCHAR(MAX)] NULL,
                                                                  [DateCreated] [DATETIME] NOT NULL
                                                              )";
                command.ExecuteNonQuery();
            }
        }
        private static long InsertFirstBlock(SqlConnection connection, string text)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO #TBL_XML
                                                            ( [XmlData] , 
                                                              [FileName] , 
                                                              [DateCreated]
                                                            ) 
                                            VALUES (@XMLData, @FileName, GETDATE()); SELECT SCOPE_IDENTITY()";
                command.Parameters.AddWithValue("@FileName", System.IO.Path.GetFileName(item.XmlFileName));
                command.Parameters.AddWithValue("@XmlData", text);
                return (long)command.ExecuteScalar();
            }
        }
        private static void AppendBlock(SqlConnection connection, long id, string text)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"UPDATE #TBL_XML
                                                SET XmlData = XmlData + @xmlData
                                        WHERE XmlFileID = @XmlFileID";
                command.Parameters.AddWithValue("@XmlData", text);
                command.Parameters.AddWithValue("@XmlFileID", id);
                command.ExecuteNonQuery();
            }
        }
        private static long CopyRecordFromTemp(SqlConnection connection, long id)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO [dbo].[TBL_XML] ([XmlData], [FileName], [DateCreated])
                                        SELECT CONVERT(xml, [XmlData]), [FileName], [DateCreated]
                                        FROM #TBL_XML
                                        WHERE XmlFileID = @XmlFileID; SELECT SCOPE_IDENTITY()";
                return (long)command.ExecuteScalar();
            }
        }
