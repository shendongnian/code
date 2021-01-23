        [HttpPost]
        public PartialViewResult DeleteAttachment(int id)
        {
            Upload UploadToDelete = CandidateProxy.GetUploadByID(this.CurrentUser.DbInfo, id);
            return PartialView(UploadToDelete);
        }
