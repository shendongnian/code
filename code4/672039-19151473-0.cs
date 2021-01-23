           internal bool UploadUsingHighLevelAPI(String FilePath, ChunkDetails ObjMetaData,
                                                S3Operations.UploadType uploadType,
           Stream inputStream)
           {
           String METHOD_NAME = "UploadUsingHighLevelAPI";
            String keyName;
            String existingBucketName;
            TransferUtilityUploadRequest fileTransferUtilityRequest = null;
            int RetryTimes = 3;
            ThrottledStream throttleStreamObj = null;
            
            long bps = ThrottledStream.Infinite;
            try
            {
                keyName = ObjMetaData.KeyName;
                existingBucketName = ObjMetaData.BucketName;
                TransferUtility fileTransferUtility = new
                        TransferUtility(ObjMetaData.AccessKeyID,        ObjMetaData.SecretAccessKey);
                FileInfo fin = new FileInfo(FilePath);
                //streamObj = new FileStream(FilePath, FileMode.Open);
                bps = (long)(1024 * ObjMetaData.MaxAvailSpeed * ((double)ObjMetaData.Bandwidth / 100.0));
              
                throttleStreamObj = new ThrottledStream(ObjMetaData.FileStream, bps);
                System.Collections.Specialized.NameValueCollection metaInfo = new System.Collections.Specialized.NameValueCollection();
                if (ObjMetaData.MetaInfo != null)
                {
                    foreach (DictionaryEntry kvp in ObjMetaData.MetaInfo)
                    {
                        metaInfo.Add(kvp.Key.ToString(), kvp.Value.ToString());
                    }
                }
                long OffDiff = ObjMetaData.EndOffset - ObjMetaData.StartOffset;
                long partSize;
                if (fin.Length >= OffDiff)
                {
                    partSize = OffDiff;
                }
                else
                    partSize = fin.Length;
                if (uploadType == UploadType.File)
                {
                    //fileTransferUtility.Upload(FilePath, existingBucketName, keyName);
                    fileTransferUtilityRequest =
                    new TransferUtilityUploadRequest()
                    .WithBucketName(existingBucketName)
                    //.WithFilePath(FilePath)
                    .WithStorageClass(S3StorageClass.ReducedRedundancy)
                    .WithMetadata(metaInfo)
                    .WithPartSize(partSize)
                    .WithKey(keyName)
                    .WithCannedACL(S3CannedACL.PublicRead)
                    .WithTimeout(Int32.MaxValue - 1)
                    .WithInputStream(throttleStreamObj) as TransferUtilityUploadRequest;
                }
                else if (uploadType == UploadType.Stream)
                {
                    fileTransferUtilityRequest =
                   new TransferUtilityUploadRequest()
                   .WithBucketName(existingBucketName)
                   .WithStorageClass(S3StorageClass.ReducedRedundancy)
                   .WithMetadata(metaInfo)
                   .WithPartSize(partSize)
                   .WithKey(keyName)
                   .WithCannedACL(S3CannedACL.PublicRead)
                   .WithTimeout(Int32.MaxValue - 1)
                   .WithInputStream(throttleStreamObj) as TransferUtilityUploadRequest
                   ;
                }
                for (int index = 1; index <= RetryTimes; index++)
                {
                    try
                    {
                        // Upload part and add response to our list.
                        fileTransferUtility.Upload(fileTransferUtilityRequest);
                        Console.WriteLine(" ====== Upload Done =========");
                        if (eventChunkUploaded != null)
                            eventChunkUploaded(ObjMetaData);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (index == RetryTimes)
                        {
                            m_objLogFile.LogError(CLASS_NAME, METHOD_NAME + " - Attempt " +
                                index + Environment.NewLine + FilePath, ex);
                            if (eventChunkUploadError != null)
                                eventChunkUploadError(ObjMetaData, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_objLogFile.LogError(CLASS_NAME, METHOD_NAME, ex);
                return false;
            }
            finally
            {
               
                if (throttleStreamObj != null)
                {
                    //inputStream1.Close();
                    throttleStreamObj = null;
                }
            }
            return true;
       }
