    String savedFileName = uploadProfileImage(profileImageName, new System.Drawing.Rectangle(Int32.Parse(xaxis), Int32.Parse(yaxis), Int32.Parse(xwidth), Int32.Parse(yheight)));
    public String uploadProfileImage(string profileImageName, System.Drawing.Rectangle rectangle)
        {
            try
            {
                String retFileName = "";
                if (profileImageName != null || profileImageName != "")
                {
                    GenerateCroppedThumbNail(profileImageName, rectangle);
                }
                return retFileName;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
