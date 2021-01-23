	class Controller {
		public FileUploadJsonResult AjaxUploadProfile(int id, string branchName, string filepath, HttpPostedFileBase file) {
			string fileName = id + "_" + branchName;
			string fileExtension = _fileIO.GetExtensionForFile(file);
			if (!_extensionManager.IsValidExtension(fileExtension)) {
				return CreateAjaxUploadProfileError("Profile picture should be of JPG, BMP, PNG, GIF or JPEG format.");
			}
			
			if (file.ContentLength > _settingsManager.GetMaximumFileSize()) {
				return CreateAjaxUploadProfileError("Profile picture size should be less than 2MB");
			}
			
			string fileNameWithJPGExtension = fileName + ".jpg";
			string fileServerPath = _fileIO.GetServerProfilePicture(Server, fileNameWithJPGExtension);
			string fileClientPath = _fileIO.GetClientProfilePicture(fileNameWithJPGExtension);
			
			var dimensions = _settingsManager.GetThumbnailDimensions();
			_fileIO.SaveThumbnailImage(fileServerPath, file, dimensions.Item1, dimensions.Item2);
		
			// Return JSON      
			var data = new {
					message = "Profile Picture is successfully uploaded.", 
					filename = fileClientPath,
					profilepic = profilePicture,
					statusCode = "1"
				};
			return new FileUploadJsonResult { Data = data };
		}
		
		private static CreateAjaxUploadProfileError(string message) {
			var data = new {
					message = message, 
					filename = string.Empty,
					profilepic = string.Empty,
					statusCode = "0"
				};
			return new FileUploadJsonResult { Data = data };
		}
	}
		
	class FileIO : IFileIO {
		public string GetExtensionForFile(HttpPostedFileBase file) {
			return System.IO.Path.GetExtension(filePath.FileName.ToLower());
		}
		
		public string GetServerProfilePicture(T server, string file) {
			return server.MapPath( "~/LO_ProfilePicture/" + file);
		}
		
		public void SaveThumbnailImage(string path, HttpPostedFileBase file, int height, int width) {
			Utility.SaveThumbnailImage(path, file.InputStream, height, width); // or even inline
		}
		
		public string GetClientProfilePicture(string fileName) {
			return _settingsManager.GetClientImagePath() + "LO_ProfilePicture/" + fileNameWithJPGExtension;
		}
	}
	class ExtensionManager : IExtensionManager {
		public bool IsValidExtension(string extension) {
			return Utility.isCorrectExtension(fileExtension); // or even inline
		}
	}
	class SettingsManager : ISettingsManager {
		public Tuple<int, int> GetThumbnailDimensions() {
			return Tuple.Create<int, int>(PageConstants.BRANCH_PROFILE_PICTURE_FILE_HEIGTH, PageConstants.BRANCH_PROFILE_PICTURE_FILE_WIDTH);
		}
		
		public int GetMaximumFileSize() {
			return PageConstants.PROFILE_PICTURE_FILE_SIZE;
		}
	}
