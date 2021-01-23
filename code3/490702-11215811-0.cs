        void InitAttachment()
        {
            string attachment = "attachment; filename= " + this.FileName;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/excel";
        }
