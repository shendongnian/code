    using System;
    using System.Security.Cryptography;
    public interface ISaltedHash
    {
        /// <summary>
        /// Gets the hash.
        /// </summary>
        string Hash
        {
            get;
        }
        /// <summary>
        /// Gets the salt.
        /// </summary>
        string Salt
        {
            get;
        }
    }
    public class SaltedHashProvider
    {
        #region Fields
        
        private int m_saltLength = 6;
        #endregion // Fields
        #region Public Methods
        /// <summary>
        /// Encrypts data with the a salted SHA1 algorith. 
        /// The salt will be automatically generated.
        /// </summary>
        /// <param name="value">Value to be encrypted.</param>
        /// <returns>The encrypted data.</returns>
        public ISaltedHash EncryptWithSalt( string value )
        {
            string salt = CreateSalt();
            string hash = Encrypt( salt + value );
            return new SaltedHash
            {
                Hash = hash,
                Salt = salt
            };
        }
        /// <summary>
        /// Encrypts data with the a salted SHA1 algorith. 
        /// </summary>
        /// <param name="value">Value to be encrypted.</param>
        /// <param name="salt">Salt to be used when encypting the value.</param>
        /// <returns>The encrypted data.</returns>
        public ISaltedHash EncryptWithSalt( string value, string salt )
        {
            string hash = Encrypt( salt + value );
            return new SaltedHash
            {
                Hash = hash,
                Salt = salt
            };
        }
        #endregion // Public Methods
        #region Helper Methods
        /// <summary>
        /// Creates salt.
        /// </summary>
        /// <returns>A base64 salt string.</returns>
        private string CreateSalt()
        {
            byte[] saltBlob = CreateRandomBytes(m_saltLength);
            return Convert.ToBase64String(saltBlob);
        }
        /// <summary>
        /// Encrypts data with the SHA1 algorithm.
        /// </summary>
        /// <param name="value">Value to be encrypted.</param>
        /// <returns>The encrypted data.</returns>
        private string Encrypt( string value )
        {
            byte[] blob = ToByteArray( value );
            byte[] hash = ComputeHash( blob );
            return Convert.ToBase64String( hash );
        }
        /// <summary>
        /// Computes the hash value for the specified byte array.
        /// </summary>
        /// <param name="blob">The input to commute the hash for.</param>
        /// <returns>The computed hash code.</returns>
        private byte[] ComputeHash( byte[] blob )
        {
            return new SHA1CryptoServiceProvider().ComputeHash( blob );
        }
        /// <summary>
        /// Gets a UTF8 byte array encoding for the specified character array.
        /// </summary>
        /// <param name="value">The input containing characters to be encoded.</param>
        /// <returns>The UTF8 encoded array.</returns>
        private byte[] ToByteArray( string value )
        {
            return System.Text.Encoding.UTF8.GetBytes( value );
        }
        /// <summary>
        /// Creates a random byte array.
        /// </summary>
        /// <param name="length">Length of array to be generated.</param>
        /// <returns>A random byte array.</returns>
        private static byte[] CreateRandomBytes( int length )
        {
            byte[] blob = new byte[length];
            new RNGCryptoServiceProvider().GetBytes( blob );
            return blob;
        }
        #endregion // Helper Methods
    }
