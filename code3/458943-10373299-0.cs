    public static void CopyLogo(Company company)
        {
            if (company.CompanyLogo != null)
            {
                MemoryStream ms = new MemoryStream(company.CompanyLogo.Image, 0, company.CompanyLogo.Image.Length);
                using (ms)
                {
                    //saving image on current project directory
                    Image img = Image.FromStream(ms);
                    img.Save(Environment.CurrentDirectory+"\\"+ company.CompanyLogo.Name);
                    //copying to clipboard
                    StringCollection paths = new StringCollection();
                    paths.Add(Environment.CurrentDirectory + "\\" + company.CompanyLogo.Name);
                    Clipboard.SetFileDropList(paths);
                }
            }
        }
