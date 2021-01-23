    using System;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Exchange.WebServices.Data;
    
    namespace EmailServices.Web.IntegrationTests
    {
    	// http://msdn.microsoft.com/en-us/library/exchange/jj220499(v=exchg.80).aspx
    	internal class MsExchangeServices
    	{
    		public MsExchangeServices()
    		{
    			ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
    			m_exchangeService = new ExchangeService { UseDefaultCredentials = true };
    
    			// Who's running this test? They better have Exchange mailbox access.
    			m_exchangeService.AutodiscoverUrl(UserPrincipal.Current.EmailAddress, RedirectionUrlValidationCallback);
    		}
    
    		public ExchangeService Service { get { return m_exchangeService; } }
    
    		public Folder GetPublicFolderByPath(string ewsFolderPath)
    		{
    			string[] folders = ewsFolderPath.Split('\\');
    
    			Folder parentFolderId = null;
    			Folder actualFolder = null;
    
    			for (int i = 0; i < folders.Length; i++)
    			{
    				if (0 == i)
    				{
    					parentFolderId = GetTopLevelFolder(folders[i]);
    					actualFolder = parentFolderId;
    				}
    				else
    				{
    					actualFolder = GetFolder(parentFolderId.Id, folders[i]);
    					parentFolderId = actualFolder;
    				}
    			}
    			return actualFolder;
    		}
    
    		private static bool RedirectionUrlValidationCallback(string redirectionUrl)
    		{
    			// The default for the validation callback is to reject the URL.
    			bool result = false;
    
    			Uri redirectionUri = new Uri(redirectionUrl);
    
    			// Validate the contents of the redirection URL. In this simple validation
    			// callback, the redirection URL is considered valid if it is using HTTPS
    			// to encrypt the authentication credentials. 
    			if (redirectionUri.Scheme == "https")
    				result = true;
    
    			return result;
    		}
    
    		private static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    		{
    			// If the certificate is a valid, signed certificate, return true.
    			if (sslPolicyErrors == SslPolicyErrors.None)
    				return true;
    
    			// If there are errors in the certificate chain, look at each error to determine the cause.
    			if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == 0)
    			{
    				// In all other cases, return false.
    				return false;
    			}
    			else
    			{
    				if (chain != null)
    				{
    					foreach (X509ChainStatus status in chain.ChainStatus)
    					{
    						if ((certificate.Subject == certificate.Issuer) && (status.Status == X509ChainStatusFlags.UntrustedRoot))
    						{
    							// Self-signed certificates with an untrusted root are valid. 
    						}
    						else
    						{
    							if (status.Status != X509ChainStatusFlags.NoError)
    							{
    								// If there are any other errors in the certificate chain, the certificate is invalid,
    								// so the method returns false.
    								return false;
    							}
    						}
    					}
    				}
    
    				// When processing reaches this line, the only errors in the certificate chain are 
    				// untrusted root errors for self-signed certificates. These certificates are valid
    				// for default Exchange server installations, so return true.
    				return true;
    			}
    		}
    
    		private Folder GetTopLevelFolder(string folderName)
    		{
    			FindFoldersResults findFolderResults = m_exchangeService.FindFolders(WellKnownFolderName.PublicFoldersRoot, new FolderView(int.MaxValue));
    			foreach (Folder folder in findFolderResults.Where(folder => folderName.Equals(folder.DisplayName, StringComparison.InvariantCultureIgnoreCase)))
    				return folder;
    
    			throw new Exception("Top Level Folder not found: " + folderName);
    		}
    
    		private Folder GetFolder(FolderId parentFolderId, string folderName)
    		{
    			FindFoldersResults findFolderResults = m_exchangeService.FindFolders(parentFolderId, new FolderView(int.MaxValue));
    			foreach (Folder folder in findFolderResults.Where(folder => folderName.Equals(folder.DisplayName, StringComparison.InvariantCultureIgnoreCase)))
    				return folder;
    
    			throw new Exception("Folder not found: " + folderName);
    		}
    
    		readonly ExchangeService m_exchangeService;
    	}
    }
