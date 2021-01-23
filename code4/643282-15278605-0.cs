	class Controller {
		public FileUploadJsonResult AjaxUploadProfile(int id, string branchName, string filepath, HttpPostedFileBase file) {
			string fileName = id + "_" + branchName;
			string fileExtension = _fileIO.GetExtensionForFile(file);
			string statusMessage;
			string profilePicture = string.Empty;
			string returningFileName = string.Empty;
			string statusCode;
			
			if (string.IsNullOrEmpty(fileExtension) || !_extensionManager.IsValidExtension(fileExtension)) {
				statusMessage = "Profile picture should be of JPG, BMP, PNG, GIF or JPEG format.";
				statusCode = "0";
			} else if (file.ContentLength > _settingsManager.GetMaximumFileSize()) {
				statusMessage = "Profile picture size should be less than 2MB";
				statusCode = "0";
			} else {
				string fileNameWithJPGExtension = fileName + ".jpg";
				string fileServerPath = _fileIO.MapPath(Server, "~/LO_ProfilePicture/" + fileNameWithJPGExtension);
			
				var dimensions = _settingsManager.GetThumbnailDimensions();
				_fileIO.SaveThumbnailImage(fileServerPath, file, dimensions.Item1, dimensions.Item2);
			
				statusMessage = "Profile Picture is successfully uploaded.";
				profilePicture = PageConstants.IMAGE_PATH + "LO_ProfilePicture/" + fileNameWithJPGExtension;
				returningFileName = fileNameWithJPGExtension;
				statusCode = "1";
			}
		
			// Return JSON      
			var data = new {
					message = statusMessage, 
					filename = returningFileName,
					profilepic = profilePicture,
					statusCode = statusCode
				};
			return new FileUploadJsonResult { Data = data };
		}
	}
		
	class FileIO : IFileIO {
		public string GetExtensionForFile(HttpPostedFileBase file) {
			return System.IO.Path.GetExtension(filePath.FileName.ToLower());
		}
		
		public string MapPath(T server, string file) {
			return server.MapPath(file);
		}
		
		public void SaveThumbnailImage(string path, HttpPostedFileBase file, int height, int width) {
			Utility.SaveThumbnailImage(path, file.InputStream, height, width); // or even inline
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
