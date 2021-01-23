                byte[] key = new byte[16];
                HaspFeature feature = HaspFeature.FromFeature(4);
                string vendorCode = "your vendor string, get it from your tools";
                Hasp hasp = new Hasp(feature);
                HaspStatus status = hasp.Login(vendorCode);
                if (HaspStatus.StatusOk != status)
                {
                    //  no license to run
                    return false;
                }
                else
                {
                    //  read some memory here
                    HaspFile mem = hasp.GetFile(HaspFileId.ReadOnly);
                    mem.Read(key, 0, 16);
                    status = hasp.Logout();
                    if (HaspStatus.StatusOk != status)
                    {
                        //handle error
                    }
                }
  
