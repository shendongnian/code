      private static void SetSslCertHash(string siteId, byte[] hash)
      {
        using (var adminBase = TemporaryComObject.Wrap(new MSAdminBase_W()))
        using (var ptrHash = new AllocHGlobal(hash))
        {
          using (var siteKey = new AdminBaseKey(adminBase.Com, adminBase.Com.OpenKey(METADATA_MASTER_ROOT_HANDLE, "/LM/W3SVC/" + siteId, METADATA_PERMISSION_READ | METADATA_PERMISSION_WRITE, 1000)))
          {
            var record = new METADATA_RECORD
            {
              dwMDIdentifier = SslCertHashCode,
              dwMDAttributes = METADATA_INHERIT,
              dwMDUserType = IIS_MD_UT_SERVER,
              dwMDDataType = BINARY_METADATA,
              pbMDData = ptrHash.Buffer,
              dwMDDataLen = hash.Length
            };
            adminBase.Com.SetData(siteKey.Handle, string.Empty, ref record);
          }
          adminBase.Com.SaveData();
        }
      }
