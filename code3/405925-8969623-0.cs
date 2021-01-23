    public static bool WriteFile(ByteBuffer data, string fileName, bool append)
    {
      StreamWriter writer = null;
      try
      {
         writer = new StreamWriter(fileName, append);
         writer.Write(data);
         return true;
      }
      catch (Exception ex)
      {
         // Log exception
         return false;
      }
      finally
      {
         if (writer != null)
         {
            try {
               writer.Close();
            } catch (EncoderFallbackException) { /* arguably log this as well */ }
         }
      }
    }
