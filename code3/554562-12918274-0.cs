        // For Tasks
        private static Task _taskUpload = null;
        private static string _fPath = "";
        private static string _userMsg = "";
        private static string _imgType = "";
        /// <summary>
        /// used to post photo to facebook
        /// </summary>
        /// <param name="fPath"></param>
        /// <param name="userMsg"></param>
        /// <param name="imgType"></param>
        public static void uploadPhoto(string filePath, string userMsg, string imgType = "")
        {
            // Assign Values
            _fPath = filePath;
            _userMsg = userMsg;
            _imgType = imgType;
            // Start Task
            _taskUpload = Task.Factory.StartNew(new Action(processUploadPhoto));
        }
        /// <summary>
        /// Used to process actual upload of photo to FB
        /// </summary>
        private static void processUploadPhoto()
        {
            var fb = new FacebookClient(AccessToken);
            if (_imgType.Equals(""))
                _imgType = "image/jpeg";
            using (var file = new FacebookMediaStream
            {
                ContentType = _imgType,
                FileName = Path.GetFileName(_fPath)
            }.SetValue(File.OpenRead(_fPath)))
            {
                dynamic result = fb.Post("me/photos",
                    new { message = _userMsg, file });
            }
        }
