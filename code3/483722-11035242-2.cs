    [HttpPost]
    public void UploadDocument(DocumentModel model)
    {
       if(ModelState.IsValid)
       {
          string thatValue=model.SelectedType;
       }
    }
