    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Drawing;
    using System.IO;
    using System.Transactions;
    
    namespace PhotoLibraryApp
    {
      public class PhotoData
      {
        private const string ConnStr =
          "Data Source=.;Integrated Security=True;Initial Catalog=PhotoLibrary;";
    
        public static void InsertPhoto
          (int photoId, string desc, string filename)
        {
          const string InsertTSql = @"
            INSERT INTO PhotoAlbum(PhotoId, Description)
              VALUES(@PhotoId, @Description);
            SELECT Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT()
              FROM PhotoAlbum
              WHERE PhotoId = @PhotoId";
    
          string serverPath;
          byte[] serverTxn;
    
          using (TransactionScope ts = new TransactionScope())
          {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
              conn.Open();
    
              using (SqlCommand cmd = new SqlCommand(InsertTSql, conn))
              {
                cmd.Parameters.Add("@PhotoId", SqlDbType.Int).Value = photoId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = desc;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                  rdr.Read();
                  serverPath = rdr.GetSqlString(0).Value;
                  serverTxn = rdr.GetSqlBinary(1).Value;
                  rdr.Close();
                }
              }
              SavePhotoFile(filename, serverPath, serverTxn);
            }
            ts.Complete();
          }
        }
    
        private static void SavePhotoFile
          (string clientPath, string serverPath, byte[] serverTxn)
        {
          const int BlockSize = 1024 * 512;
    
          using (FileStream source =
            new FileStream(clientPath, FileMode.Open, FileAccess.Read))
          {
            using (SqlFileStream dest =
              new SqlFileStream(serverPath, serverTxn, FileAccess.Write))
            {
              byte[] buffer = new byte[BlockSize];
              int bytesRead;
              while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
              {
                dest.Write(buffer, 0, bytesRead);
                dest.Flush();
              }
              dest.Close();
            }
            source.Close();
          }
        }
    
        public static Image SelectPhoto(int photoId, out string desc)
        {
          const string SelectTSql = @"
            SELECT
                Description,
                Photo.PathName(),
                GET_FILESTREAM_TRANSACTION_CONTEXT()
              FROM PhotoAlbum
              WHERE PhotoId = @PhotoId";
    
          Image photo;
          string serverPath;
          byte[] serverTxn;
    
          using (TransactionScope ts = new TransactionScope())
          {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
              conn.Open();
    
              using (SqlCommand cmd = new SqlCommand(SelectTSql, conn))
              {
                cmd.Parameters.Add("@PhotoId", SqlDbType.Int).Value = photoId;
    
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                  rdr.Read();
                  desc = rdr.GetSqlString(0).Value;
                  serverPath = rdr.GetSqlString(1).Value;
                  serverTxn = rdr.GetSqlBinary(2).Value;
                  rdr.Close();
                }
              }
              photo = LoadPhotoImage(serverPath, serverTxn);
            }
    
            ts.Complete();
          }
    
          return photo;
        }
    
        private static Image LoadPhotoImage(string filePath, byte[] txnToken)
        {
          Image photo;
    
          using (SqlFileStream sfs =
            new SqlFileStream(filePath, txnToken, FileAccess.Read))
          {
            photo = Image.FromStream(sfs);
            sfs.Close();
          }
    
          return photo;
        }
    
      }
    }
