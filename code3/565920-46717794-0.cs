    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    /// <summary>
    /// Extension methods for <see cref="CloudBlockBlob"/>
    /// </summary>
    public static class CloudBlockBlobExtensions
    {
        /// <summary>
        /// Attempts to open a stream to download a range, and if it fails with <see cref="StorageException"/> 
        /// then the message is compared to a string representation of the expected message if the MD5
        /// property does not match the property sent.
        /// </summary>
        /// <param name="instance">The instance of <see cref="CloudBlockBlob"/></param>
        /// <returns>Returns a false if the calculated MD5 does not match the existing property.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="instance"/> is null.</exception>
        /// <remarks>This is a hack, and if the message from storage API changes, then this will fail.</remarks>
        public static async Task<bool> IsValidContentMD5(this CloudBlockBlob instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            try
            {
                using (var ms = new MemoryStream())
                {
                    await instance.DownloadRangeToStreamAsync(ms, null, null);
                }
            }
            catch (StorageException ex)
            {
                return !ex.Message.Equals("Calculated MD5 does not match existing property", StringComparison.Ordinal);
            }
            return true;
        }
    } 
