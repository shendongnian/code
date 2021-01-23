        if (Convert.ToDateTime(date).CompareTo(System.DateTime.Now) < 0)
        {
            Button6.Enabled = false;
        }
        else
        {
            DownLoadFileFromServer("~/NewFolder1/" + "Fundamentals of IS.pdf");
        }
