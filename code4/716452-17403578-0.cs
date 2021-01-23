		public void RunScriptInGuestOs(string vCenterUrl, string vCenterUserName, string vCenterPassword, string scriptFilePatch, string vmKey, string username, string password, string destinationFilePath, string arguments)
		{
			var service = CreateVimService(vCenterUrl, 600000, true);
			var serviceContent = RetrieveServiceContent(service);
			service.Login(serviceContent.sessionManager, vCenterUserName, vCenterPassword, null);
			byte[] dataFile;
			using (var fileStream = new FileStream(scriptFilePatch, FileMode.Open, FileAccess.Read))
			{
				dataFile = new byte[fileStream.Length];
				fileStream.Read(dataFile, 0, dataFile.Length);
			}
			FileTransferToGuest(service, vmKey, username, password, destinationFilePath, dataFile);
			RunProgramInGuest(service, vmKey, username, password, destinationFilePath, arguments);
		}
		private static VimService CreateVimService(string url, int serviceTimeout, bool trustAllCertificates)
		{
			if (trustAllCertificates)
			{
				ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
			}
			else
			{
				ServicePointManager.CertificatePolicy = new CertPolicy();
			}
			return new VimService
			{
				Url = url,
				Timeout = serviceTimeout,
				CookieContainer = new CookieContainer()
			};
		}
		private ServiceContent RetrieveServiceContent(VimService service)
		{
			var serviceInstance = new ManagedObjectReference
			{
				type = "ServiceInstance",
				Value = "ServiceInstance"	
			};
			var content = service.RetrieveServiceContent(serviceInstance);
			if (content.sessionManager == null)
			{
				throw new VMIntegrationException("Session manager is null.");
			}
			return content;
		}
		private void FileTransferToGuest(VimService service, string vmKey, string username, string password, string fileName, byte[] fileData)
		{
			var auth = new NamePasswordAuthentication { username = username, password = password, interactiveSession = false };
			var vmRef = new ManagedObjectReference { type = "VirtualMachine", Value = vmKey };
			var fileMgr = new ManagedObjectReference { type = "GuestFileManager", Value = "guestOperationsFileManager" };
			var posixFileAttributes = new GuestPosixFileAttributes();
			posixFileAttributes.ownerId = 1;
			posixFileAttributes.groupId = 1;
			posixFileAttributes.permissions = (long)0777; //execution file
			var requestUrl = service.InitiateFileTransferToGuest(fileMgr, vmRef, auth, fileName, posixFileAttributes, fileData.Length, true);
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
			request.ContentType = "application/octet-stream";
			request.Method = "PUT";
			request.ContentLength = fileData.Length;
			Stream requestStream = request.GetRequestStream();
			requestStream.Write(fileData, 0, fileData.Length);
			requestStream.Close();
			request.GetResponse();
		}
		private void RunProgramInGuest(VimService service, string vmKey, string username, string password, string programPath, string arguments)
		{
			var auth = new NamePasswordAuthentication { username = username, password = password, interactiveSession = false };
			var vmRef = new ManagedObjectReference { type = "VirtualMachine", Value = vmKey };
			var progSpec = new GuestProgramSpec { programPath = programPath, arguments = arguments };
			var processMgr = new ManagedObjectReference { type = "GuestProcessManager", Value = "guestOperationsProcessManager" };
			service.StartProgramInGuest(processMgr, vmRef, auth, progSpec);
		}
