    //it may need to be improved
    	Dictionary<string, SavingSettings> SaveVersions = new Dictionary<string, SavingSettings>();
    	public void page_load(object sender, EventArgs e) {
    		//set versions:
    		SaveVersions.Add("xxl", new SavingSettings("xxl", new ImageResizer.ResizeSettings())); //original size
    		SaveVersions.Add("600px", new SavingSettings("600px", new ImageResizer.ResizeSettings(600, 600, ImageResizer.FitMode.Max, "jpg"))); //big
    		SaveVersions.Add("80px", new SavingSettings("80px", new ImageResizer.ResizeSettings(80, 80, ImageResizer.FitMode.Max, "jpg"))); //80 px thumb
    		SaveVersions.Add("260w", new SavingSettings("260w", new ImageResizer.ResizeSettings(260, 0, ImageResizer.FitMode.Max, "jpg"))); //260 px width thumb
    
    	}
    
    	public void SaveIt(string SourceFile,string TargetFileName) {
    		using(System.Drawing.Bitmap bmp = ImageResizer.ImageBuilder.Current.LoadImage(SourceFile, new ImageResizer.ResizeSettings())) {
    			foreach(System.Collections.Generic.KeyValuePair<string, SavingSettings> k in SaveVersions) {
    				string TargetFilePath = Server.MapPath("../img/" + k.Value.VersionName + "/" + TargetFileName + ".jpg");
    				string TargetFolder = Server.MapPath("../img/" + k.Value.VersionName);
    				if(!System.IO.Directory.Exists(TargetFolder)) System.IO.Directory.CreateDirectory(TargetFolder);
    				if(bmp.Width > k.Value.ResizeSetting.Width || bmp.Height > k.Value.ResizeSetting.Height) {
    					//you may need to resize
    					ImageResizer.ImageBuilder.Current.Build(bmp, TargetFilePath, k.Value.ResizeSetting, false);
    				} else {
    					//just copy it
    					//or in your example you can save uploaded file
    					System.IO.File.Copy(SourceFile, TargetFilePath);
    				}
    			}
    		}
    	}
    
    	struct SavingSettings {
    		public string VersionName;
    		public ImageResizer.ResizeSettings ResizeSetting;
    		public SavingSettings(string VersionName, ImageResizer.ResizeSettings ResizeSetting) {
    			this.VersionName = VersionName;
    			this.ResizeSetting = ResizeSetting;
    		}
    	}
