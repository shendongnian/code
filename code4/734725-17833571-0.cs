          public FileContentResult GetLogoImage(int id)
        {
            var logo = _adminPractice.GetAll().FirstOrDefault(n => n.ID == id);
            if (logo != null && logo.PracticeLogo != null)
            {
                return new FileContentResult(logo.PracticeLogo, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
