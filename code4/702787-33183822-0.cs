            try
            {
                var form = request.Content.ReadAsFormDataAsync().Result;
                var modelN = JsonConvert.DeserializeObject<LoginModel>(form["json"].ToString());
                //  token = JsonConvert.DeserializeObject<string>(form["token"].ToString());
                bool istoken = _appdevice.GettokenID(modelN.DeviceId);
                if (!istoken)
                {
                    statuscode = 0;
                    message = ErrorMessage.TockenNotvalid;
                    goto invalidtoken;
                }
                User model = new User();
                // var session = HttpContext.Current.Session;
                // session.Add("UserRole", GetProfileId.UserRole);
                var user = await _userManager.FindAsync(modelN.Username, modelN.Password);}}
