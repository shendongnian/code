    public class S3CopyMemoryStream : MemoryStream
        {
            public S3CopyMemoryStream WithS3CopyFileStreamEvent(StartUploadS3CopyFileStreamEvent doing)
            {
                S3CopyMemoryStream s3CopyStream = new S3CopyMemoryStream(this._key, this._buffer, this._transferUtility);
                s3CopyStream.StartUploadS3FileStreamEvent = new S3CopyMemoryStream.StartUploadS3CopyFileStreamEvent(CreateMultiPartS3Blob);
                return s3CopyStream;
            }
            public S3CopyMemoryStream(string key, byte[] buffer, S3TransferUtility transferUtility)
                : base(buffer)
            {
                if (buffer.LongLength > int.MaxValue)
                    throw new ArgumentException("The length of the buffer may not be longer than int.MaxValue", "buffer");
                InitiatingPart = true;
                EndOfPart = false;
                WriteCount = 1;
                PartETagCollection = new List<PartETag>();
                
                _buffer = buffer;
                _key = key;
                _transferUtility = transferUtility;
            }
