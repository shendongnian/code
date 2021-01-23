    using System;
    using System.Data.SqlClient;
     
    namespace Testbeispiel_Encryption
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			//create a new instance of MyDecryptor
    			MyDecryptor Decryptor = new MyDecryptor();
    			//not recommended to store password as a cleartext (but for development purposes ;) 
    			string password = "TestEncryption123";
    			System.Security.SecureString securePassword = new System.Security.SecureString();
    			//create Secure Password
    			foreach (char keyChar in password.ToCharArray())
    				securePassword.AppendChar(keyChar);
    			//Insert Connection String (local because I am working on the Server)
    			string constr = "DATA SOURCE=(local);INITIAL CATALOG=TestEncryptionDecryption;INTEGRATED SECURITY=SSPI;";
    			using (SqlConnection con = new SqlConnection(constr))
    			{
    				//Open the connection to the initial catalog
    				con.Open();
    				//create SELECT statement
    				string cmdstr1 = "SELECT intCol, clearTextCol, encryptedCol FROM dbo.Encrypt";
     
    				using (SqlCommand cmd = new SqlCommand(cmdstr1, con))
    				{
    					SqlDataReader reader = cmd.ExecuteReader();
    					//now we read data
    					while (reader.Read())
    					{
    						try
    						{
    							Console.Write(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" );
    							Console.WriteLine(Decryptor.DecryptDocIDWithFileCert(@"C:\temp\createCert\TestCertificate.pfx", securePassword, (byte[])reader[2]));
    						}
    						catch (Exception e)
    						{
    							Console.WriteLine(e.ToString());
    							break;
    						}
    					}
    					reader.Close();
    				}
    				con.Close();
    			}
    			Console.ReadKey();
    		}
    	}
    }
